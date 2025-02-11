using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Cryptography;

namespace SharpWipe
{
	class Wipe
	{

		private RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

		/// <summary>
		/// Deletes a file in a secure way by overwriting it with
		/// random garbage data n times.
		/// </summary>
		/// <param name="filename">Full path of the file to be deleted</param>
		/// <param name="timesToWrite">Specifies the number of times the file should be overwritten</param>
		public void WipeFile(string filename, int timesToWrite)
		{
			wipeFileCore(filename, timesToWrite);
		}

		public void WipeFolder(string folderName, int timesToWrite)
		{
			try
			{
				Console.WriteLine("Tung Anh WipeFolder() folderName: " + folderName + " exist: " + Directory.Exists(folderName));
				string[] fileNameList = Directory.GetFiles(folderName);
				if (fileNameList.Length == 0)
				{
					//todo: handle case empty
				}

				//todo: handle case folder in folder
				foreach (string fileName in fileNameList)
				{
					wipeFileCore(fileName, timesToWrite);
				}

				//todo: when done, remove containing folder
			}
			catch (Exception e)
			{
				WipeError(e);
			}
		}

		private void wipeFileCore(string fileName, int timesToWrite)
		{
			try
			{
				Console.WriteLine("Tung Anh wipeFileCore() fileName: " + fileName + " exist: " + File.Exists(fileName));

				if (File.Exists(fileName))
				{
					// Set the files attributes to normal in case it's read-only.

					FileAttributes fileAttributes = File.GetAttributes(fileName);
					FileSecurity fileSecurity = File.GetAccessControl(fileName);
					FileSystemAccessRule fileSystemAccessRule = new FileSystemAccessRule(@"admin", FileSystemRights.FullControl, AccessControlType.Allow);
					fileSecurity.AddAccessRule(fileSystemAccessRule);

					File.SetAccessControl(fileName, fileSecurity);
					Console.WriteLine("Tung Anh WipeFile() fileName: " + fileName + "; attribute: " + fileAttributes.ToString());

					//File.SetAttributes(fileName, FileAttributes.Normal);

					// Calculate the total number of sectors in the file.
					double sectors = Math.Ceiling(new FileInfo(fileName).Length / 512.0);

					// Create a dummy-buffer the size of a sector.
					byte[] dummyBuffer = new byte[512];

					// Open a FileStream to the file.
					FileStream inputStream = new FileStream(fileName, FileMode.Open);
					for (int currentPass = 0; currentPass < timesToWrite; currentPass++)
					{
						UpdatePassInfo(currentPass + 1, timesToWrite, fileName);

						// Go to the beginning of the stream
						inputStream.Position = 0;

						// Loop all sectors
						for (int sectorsWritten = 0; sectorsWritten < sectors; sectorsWritten++)
						{
							UpdateSectorInfo(sectorsWritten + 1, (int)sectors);

							// Fill the dummy-buffer with random data
							rng.GetBytes(dummyBuffer);
							// Write it to the stream
							inputStream.Write(dummyBuffer, 0, dummyBuffer.Length);
						}
					}
					// Truncate the file to 0 bytes.
					// This will hide the original file-length if you try to recover the file.
					inputStream.SetLength(0);
					// Close the stream.
					inputStream.Close();

					// As an extra precaution I change the dates of the file so the

					// original dates are hidden if you try to recover the file.
					DateTime dt = new DateTime(2037, 1, 1, 0, 0, 0);
					File.SetCreationTime(fileName, dt);
					File.SetLastAccessTime(fileName, dt);
					File.SetLastWriteTime(fileName, dt);

					File.SetCreationTimeUtc(fileName, dt);
					File.SetLastAccessTimeUtc(fileName, dt);
					File.SetLastWriteTimeUtc(fileName, dt);
					//todo ghewriogjrel
					//todo: ghewriogjrel
					//TODO geriojgre
					//TODO: geriojgre

					// Finally, delete the file
					File.Delete(fileName);
					WipeDone();
				}
			}
			catch (Exception e)
			{
				WipeError(e);
			}
		}

		#region Events
		public event PassInfoEventHandler PassInfoEvent;
		private void UpdatePassInfo(int currentPass, int totalPasses, string currentFileName)
		{
			PassInfoEvent(new PassInfoEventArgs(currentPass, totalPasses, currentFileName));
		}

		public event SectorInfoEventHandler SectorInfoEvent;
		private void UpdateSectorInfo(int currentSector, int totalSectors)
		{
			SectorInfoEvent(new SectorInfoEventArgs(currentSector, totalSectors));
		}

		public event WipeDoneEventHandler WipeDoneEvent;
		private void WipeDone()
		{
			WipeDoneEvent(new WipeDoneEventArgs());
		}

		public event WipeErrorEventHandler WipeErrorEvent;
		private void WipeError(Exception e)
		{
			WipeErrorEvent(new WipeErrorEventArgs(e));
		}
		#endregion
	}

	#region Events
	#region PassInfo
	public delegate void PassInfoEventHandler(PassInfoEventArgs e);
	public class PassInfoEventArgs : EventArgs
	{
		private readonly int cPass;
		private readonly int tPass;
		private readonly string currentFileName;

		public PassInfoEventArgs(int currentPass, int totalPasses, string currentFileName)
		{
			cPass = currentPass;
			tPass = totalPasses;
			this.currentFileName = currentFileName;
		}

		/// <summary> Get the current pass </summary>
		public int CurrentPass { get { return cPass; } }
		/// <summary> Get the total number of passes to be run </summary> 
		public int TotalPasses { get { return tPass; } }

		public string CurrentFileName { get { return currentFileName; } }
	}
	#endregion

	#region SectorInfo        
	public delegate void SectorInfoEventHandler(SectorInfoEventArgs e);
	public class SectorInfoEventArgs : EventArgs
	{
		private readonly int cSector;
		private readonly int tSectors;

		public SectorInfoEventArgs(int currentSector, int totalSectors)
		{
			cSector = currentSector;
			tSectors = totalSectors;
		}

		/// <summary> Get the current sector </summary> 
		public int CurrentSector { get { return cSector; } }
		/// <summary> Get the total number of sectors to be run </summary> 
		public int TotalSectors { get { return tSectors; } }
	}
	#endregion

	#region WipeDone        
	public delegate void WipeDoneEventHandler(WipeDoneEventArgs e);
	public class WipeDoneEventArgs : EventArgs
	{
	}
	#endregion

	#region WipeError
	public delegate void WipeErrorEventHandler(WipeErrorEventArgs e);
	public class WipeErrorEventArgs : EventArgs
	{
		private readonly Exception e;

		public WipeErrorEventArgs(Exception error)
		{
			e = error;
		}

		public Exception WipeError { get { return e; } }
	}
	#endregion
	#endregion
}