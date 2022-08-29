using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using PatientsInfo.Data;
using PatientsInfo.Entities;

using System.Text.RegularExpressions;

namespace FileIO{

	/// <summary>
	/// Клас для створення та завантаження xml файлів
	/// </summary>
	public class XmlFileIoController : IFileIoController {
		/// <summary>
		/// Формат файлу
		/// </summary>
		private string fileExtension = ".pixml";

		/// <summary>
		/// 
		/// </summary>
		public string FileExtension {
			get { return fileExtension; }
			set {
				if (value == null || !Regex.IsMatch(value, @"^\.\w*xml$")) {
					throw new FormatException(
							"Розширення файлу з даними xml-типу "
							+ "повинно об'єднувати латинськісимволи крапки");
				}
				this.fileExtension = value.Trim().ToLower();
			}
		}
		private void WriteDiseases(IEnumerable<Disease> collection, XmlWriter writer) {
			writer.WriteStartElement("DiseaseData"); //<DiseaseData>
			foreach (var inst in collection) {
				// Name, CodeICD, Description
				writer.WriteStartElement("Disease");
				writer.WriteElementString("Name", inst.Name);
				writer.WriteElementString("CodeICD", inst.CodeICD); // <ID>2<ID/>
				writer.WriteElementString("Description", inst.Description);
				writer.WriteEndElement(); //<Disease/>
			}
			writer.WriteEndElement();
		}

		private void WritePatients(IEnumerable<Patient> collection, XmlWriter writer) {
			writer.WriteStartElement("PatientData"); //<DiseaseData>
			foreach (var inst in collection) {
				//Key, Person, disease, IsSick, Comment
				writer.WriteStartElement("Patient");
				writer.WriteElementString("Person", inst.Person?.FullName); // <ID>2<ID/>
				writer.WriteElementString("Description", inst.disease?.Name);
				writer.WriteElementString("IsSick", inst.IsSick?.ToString());
				writer.WriteElementString("Comment", inst.Comment);
				writer.WriteEndElement(); //<Disease/>
			}
			writer.WriteEndElement();
		}

		private void WritePeople(IEnumerable<Person> collection, XmlWriter writer) {
			writer.WriteStartElement("PeopleData"); //<DiseaseData>
			foreach (var inst in collection) {
				//PersonalNumber, FullName, DiseaseOnsetDate, DateBirth, Gender, PhoneNumber, ResidenceAddress, HealthStatus, TypeBlood, Comment;
				writer.WriteStartElement("Person");
				writer.WriteElementString("FullName", inst.FullName); // <ID>2<ID/>
				writer.WriteElementString("DiseaseOnsetDate", inst.DiseaseOnsetDate.ToShortDateString());
				writer.WriteElementString("DateBirth", inst.DateBirth.ToShortDateString());
				writer.WriteElementString("Gender", ((byte)inst.Gender).ToString());
				writer.WriteElementString("PhoneNumber", inst.PhoneNumber);
				writer.WriteElementString("ResidenceAddress", inst.ResidenceAddress);
				writer.WriteElementString("HealthStatus", ((byte)inst.HealthStatus).ToString());
				writer.WriteElementString("TypeBlood", inst.TypeBlood);
				writer.WriteElementString("Comment", inst.Comment);
				writer.WriteEndElement(); //<Disease/>
			}
			writer.WriteEndElement();
		}

		private void WriteData(DataSet dataSet, XmlWriter writer) {
			writer.WriteStartDocument();
				writer.WriteStartElement("PatientInfo");
					WriteDiseases(dataSet.Diseases, writer);
					WritePeople(dataSet.People, writer);
					WritePatients(dataSet.Patients, writer);
				writer.WriteEndElement();
			writer.WriteEndDocument();
		}

		public void Save(DataSet dataSet, string fileName) {
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Encoding = Encoding.Unicode;

			XmlWriter writer = null;

			try {
				writer = XmlWriter.Create(fileName + fileExtension, settings);
				WriteData(dataSet, writer);
			}
			catch (Exception) {
				throw;
			}
			finally {
				if (writer != null) writer.Close();
			}
		}

		public void Load(DataSet dataSet, string fileName) {
			fileName = Path.ChangeExtension(fileName, FileExtension);
			if (!File.Exists(fileName)) return;
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.IgnoreWhitespace = true;

			using (XmlReader reader = XmlReader.Create(fileName, settings)) {
				while (reader.Read()) {
					if (reader.NodeType == XmlNodeType.Element) {
						switch (reader.Name) {
							case "Disease": {
								ReadDisease(reader, dataSet);
								break;
							}
							case "Person": {
								ReadPerson(reader, dataSet);
								break;
							}
							case "Patient": {
								ReadPatient(reader, dataSet);
								break;
							}
						}
					}
				}
			}
		}

		private void ReadDisease(XmlReader xmlReader, DataSet dataSet) {
			// Name, CodeICD, Description
			Disease inst = new Disease();
			xmlReader.ReadStartElement("Disease");
			inst.Name = xmlReader.ReadElementContentAsString();
			inst.CodeICD = xmlReader.ReadElementContentAsString();
			inst.Description = xmlReader.ReadElementContentAsString();
			dataSet.Diseases.Add(inst);
		}

		private void ReadPatient(XmlReader reader, DataSet dataSet) {
			//Key, Person, disease, IsSick, Comment

			Patient inst = new Patient();
			string str;
			reader.ReadStartElement("Patient");

			str = reader.ReadElementContentAsString();
			inst.Person = dataSet.People.FirstOrDefault(e => e.FullName == str);

			str = reader.ReadElementContentAsString();
			inst.disease = dataSet.Diseases.FirstOrDefault(e => e.Name == str);

			str = reader.ReadElementContentAsString();
			inst.IsSick = str.Length == 0 ? (bool?)null : str.ToUpper() == "TRUE" ? true : false;

			inst.Comment = reader.ReadElementContentAsString();

			dataSet.Patients.Add(inst);
		}

		private void ReadPerson(XmlReader reader, DataSet dataSet) {
			//PersonalNumber, FullName, DiseaseOnsetDate, DateBirth, Gender, PhoneNumber, ResidenceAddress, HealthStatus, TypeBlood, Comment;
			Person inst = new Person();
			reader.ReadStartElement("Person");
			inst.FullName = reader.ReadElementContentAsString();
			inst.DiseaseOnsetDate = Convert.ToDateTime(reader.ReadElementContentAsString());
			inst.DateBirth = Convert.ToDateTime(reader.ReadElementContentAsString());
			inst.Gender = (PatientsInfo.Entities.Enum.Gender)reader.ReadElementContentAsInt();
			inst.PhoneNumber = reader.ReadElementContentAsString();
			inst.ResidenceAddress = reader.ReadElementContentAsString();
			inst.HealthStatus = (PatientsInfo.Entities.Enum.HealthStatus)reader.ReadElementContentAsInt();
			inst.TypeBlood = reader.ReadElementContentAsString();
			inst.Comment = reader.ReadElementContentAsString();

			dataSet.People.Add(inst);
		}

	}
}
