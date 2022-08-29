using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using PatientsInfo.Data;

namespace FileIO {
	public class XAttributeIoController : IFileIoController {
		public string FileExtension { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void Load(DataSet dataSet, string fileName) {
			throw new NotImplementedException();
		}

		public void Save(DataSet dataSet, string fileName) {
			XDocument xDocument = new XDocument(new XElement("PatientsInfo", SaveDiseases(dataSet), SavePeople(dataSet), SavePatients(dataSet)));
			xDocument.Declaration = new XDeclaration("1.0", "utf-8", "true");
			xDocument.Save("text.xml");
		}

		private XElement SaveDiseases(DataSet dataSet) {
			// Name, CodeICD, Description
			XElement ret = new XElement("Diseases");
			foreach (var el in dataSet.Diseases) {
				ret.Add(
				new XElement("Disease",
					new XAttribute("name", el.Name),
					new XAttribute("CodeICD", el.CodeICD),
					new XAttribute("Description", el.Description)));
			}
			return ret;
		}
		
		private XElement SavePeople(DataSet dataSet) {
			//PersonalNumber, FullName, DiseaseOnsetDate, DateBirth, Gender, PhoneNumber, ResidenceAddress, HealthStatus, TypeBlood, Comment;
			XElement ret = new XElement("People");
			foreach (var el in dataSet.People) {
				ret.Add(
				new XElement("Person",
					new XAttribute("FullName", el.FullName),
					new XAttribute("DiseaseOnsetDate", el.DiseaseOnsetDate),
					new XAttribute("DateBirth", el.DateBirth),
					new XAttribute("Gender", el.Gender),
					new XAttribute("PhoneNumber", el.PhoneNumber),
					new XAttribute("ResidenceAddress", el.ResidenceAddress),
					new XAttribute("HealthStatus", el.HealthStatus),
					new XAttribute("TypeBlood", el.TypeBlood),
					new XAttribute("Comment", el.Comment)));
			}
			return ret;
		}
		private XElement SavePatients(DataSet dataSet) {
			//Key, Person, disease, IsSick, Comment
			XElement ret = new XElement("Parients");
			foreach (var el in dataSet.Patients) {
				ret.Add(
				new XElement("Patient",
					new XAttribute("PersonName", el.Person?.FullName),
					new XAttribute("DiseaseName", el.disease?.Name),
					new XAttribute("IsSick", el.IsSick == null ? "" : el.IsSick.ToString()),
					new XAttribute("Comment", el.Comment)));
			}
			return ret;
		}
	}
}
