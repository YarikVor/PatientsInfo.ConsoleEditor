using System;
using System.Collections.Generic;
using System.Text;
using PatientsInfo.Data;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Web;
using PatientsInfo.Entities;

namespace FileIO.Json {
	public class JSONFileIoController : IFileIoController {
		public string FileExtension { get => fileName; set { } }
		
		string fileName = "q.json";
		public void Load(DataSet dataSet, string fileName) {
			var encoderSetings = new TextEncoderSettings();
			encoderSetings.AllowRanges(UnicodeRanges.All);

			byte[] result;
			using (FileStream stream = File.OpenRead(@"jsonTest.json")) {
				result = new byte[stream.Length];
				stream.ReadAsync(result, 0, (int)stream.Length);
			}

			ReadOnlySpan<byte> data = File.ReadAllBytes(@"jsonTest.json");

			Utf8JsonReader reader = new Utf8JsonReader(data);

			while (reader.Read()) {
				JsonTokenType tokenType = reader.TokenType;
				ReadOnlySpan<byte> valueSpan = reader.ValueSpan;
				if (tokenType == JsonTokenType.PropertyName) {
					string propertyName = reader.GetString();
					switch (propertyName) {
						case "People":
							LoadPeople(dataSet, reader);
							break;
					}
				}
			}
		}

		public void LoadPeople(DataSet dataSet, Utf8JsonReader reader) {
			//PersonalNumber, FullName, DiseaseOnsetDate, DateBirth, Gender, PhoneNumber, ResidenceAddress, HealthStatus, TypeBlood, Comment;
			reader.Read();
			while (reader.TokenType != JsonTokenType.EndArray) {
				reader.Read();
				reader.Read();
				reader.Read();
				Person person = new Person();
				person.FullName = reader.GetString();
				reader.Read();
				person.DiseaseOnsetDate = reader.GetDateTime();
				person.DateBirth = reader.GetDateTime();
				person.Gender = (PatientsInfo.Entities.Enum.Gender)reader.GetInt32();
				person.PhoneNumber = reader.GetString();
				person.ResidenceAddress = reader.GetString();
				person.HealthStatus = (PatientsInfo.Entities.Enum.HealthStatus)reader.GetInt32();
				person.TypeBlood = reader.GetString();
				person.Comment = reader.GetString();

				reader.Read();
				reader.Read();
			}
		}

		public void Save(DataSet dataSet, string fileName) {
			
			Utf8JsonWriter writter;
			var encoderSetings = new TextEncoderSettings();
			encoderSetings.AllowRanges(UnicodeRanges.All);

			JsonWriterOptions options = new JsonWriterOptions(){ 
				Encoder = JavaScriptEncoder.Create(encoderSetings)
			};
				
			
			using (var fileSteam = File.OpenWrite("jsonTest.json")) {
				writter = new Utf8JsonWriter(fileSteam, options);
				writter.WriteStartObject();
				writter.WriteString("version", "v1.0");
				writter.WriteString("DataCreate", DateTime.Now.ToString());
				SavePeople(dataSet.People, writter);
				SaveDisease(dataSet.Diseases, writter);
				SavePatients(dataSet.Patients, writter);
				writter.WriteEndObject();
			}
			
		}

		public void SavePeople(List<Person> ls, Utf8JsonWriter writer) {
			writer.WriteStartArray("People");
			//PersonalNumber, FullName, DiseaseOnsetDate, DateBirth, Gender, PhoneNumber, ResidenceAddress, HealthStatus, TypeBlood, Comment;

			foreach (var obj in ls) {
				writer.WriteStartObject();
				writer.WriteString("FullName", obj.FullName);
				writer.WriteString("DiseaseOnsetDate", obj.DiseaseOnsetDate);
				writer.WriteString("DateBirth", obj.DateBirth);
				writer.WriteNumber("Gender", (byte)obj.Gender);
				writer.WriteString("PhoneNumber", obj.PhoneNumber);
				writer.WriteString("ResidenceAddress", obj.ResidenceAddress);
				writer.WriteNumber("HealthStatus", (byte)obj.HealthStatus);
				writer.WriteString("TypeBlood", obj.TypeBlood);
				writer.WriteString("Comment", obj.Comment);
				writer.WriteEndObject();
			}
			writer.WriteEndArray();
		}


		public void SaveDisease(List<Disease> ls, Utf8JsonWriter writer) {
			writer.WriteStartArray("Diseases");
			// Name, CodeICD, Description

			foreach (var obj in ls) {
				writer.WriteStartObject();
				writer.WriteString("Name", obj.Name);
				writer.WriteString("CodeICD", obj.CodeICD);
				writer.WriteString("Description", obj.Description);
				writer.WriteEndObject();
			}
			writer.WriteEndArray();
		}

		public void SavePatients(List<Patient> ls, Utf8JsonWriter writer) {
			writer.WriteStartArray("Patients");
			//Key, Person, disease, IsSick, Comment

			foreach (var obj in ls) {
				writer.WriteStartObject();

				writer.WriteString("FullName", obj.Person?.FullName.ToString());
				writer.WriteString("DiseaseOnsetDate", obj.disease?.Name.ToString());
				if (obj.IsSick == null) {
					writer.WriteNull("IsSick");
				} else {
					writer.WriteBoolean("IsSick", obj.IsSick.Value);
				}
				writer.WriteString("Comment", obj.Comment);

				writer.WriteEndObject();
			}
			writer.WriteEndArray();
		}
	}
}
