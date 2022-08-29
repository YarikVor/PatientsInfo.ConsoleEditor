using System;
using System.Collections.Generic;
using System.Text;
using PatientsInfo.Data;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
namespace FileIO.Json {
	public static class JSONCustomSettings {
		public static JsonSerializerOptions options = new JsonSerializerOptions(){
		};
		public static JsonConverterFactory converterFactory;
	}
}
