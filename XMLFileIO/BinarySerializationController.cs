using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

using PatientsInfo.Data;

namespace FileIO {
	public class BinarySerializationController : IFileIoController {
		private string fileExtension = ".cibd";

		public string FileExtension {
			get { return fileExtension; }
			set {
				if (value == null || !Regex.IsMatch(value,
						@"^\.\w*bf$")) {
					throw new FormatException(
							"Розширення файлу з даними двійкової "
							+ "серіалізації повинно об'єднувати "
							+ "символ крапки, 1-3 латинських літери, "
							+ "що вказують на предметну область, "
							+ "та сполучення символів bd (binary data), "
							+ "(за замовчанням: \".cibd\")");
				}
				this.fileExtension = value.Trim().ToLower();
			}
		}

		public void Load(DataSet dataSet, string fileName) {
			DataSet newDataSet = Load(fileName);
			if (newDataSet == null)
				return;
			foreach (var el in newDataSet.Diseases) {
				dataSet.Diseases.Add(el);
			}
			foreach (var el in newDataSet.People) {
				dataSet.People.Add(el);
			}
			foreach (var el in newDataSet.Patients) {
				dataSet.Patients.Add(el);
			}
		}

		public DataSet Load(string fileName) {
			fileName = Path.ChangeExtension(fileName, FileExtension);
			if (!File.Exists(fileName))
				return null;
			BinaryFormatter bFormatter = new BinaryFormatter();
			using (FileStream fSteam = File.OpenRead(fileName)) {
				return (DataSet)bFormatter.Deserialize(fSteam);
			}

		}

		public void Save(DataSet dataSet, string fileName) {
			fileName = Path.ChangeExtension(fileName, FileExtension);
			BinaryFormatter bFormatter = new BinaryFormatter();
			using (var fStream = new FileStream(fileName,
					FileMode.Create,
					FileAccess.Write, FileShare.None)) {
				bFormatter.Serialize(fStream, dataSet);
			}
		}
	}
}
