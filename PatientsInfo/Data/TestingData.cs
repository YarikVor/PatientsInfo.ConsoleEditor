using System;

using System.Linq;

using PatientsInfo.Entities;
using static PatientsInfo.Entities.Enum;


namespace PatientsInfo.Data {
	/// <summary>
	/// Вміст всіх сутностей
	/// </summary>
	public partial class DataContext {


		private void CreatePeople() {
			// ID = 1
			People.Add(new Person( 
				"Воробйов Ярослав Іванович",
				new DateTime(2022, 2, 6),
				new DateTime(2004, 8, 8),
				Gender.Male,
				HealthStatus.Satisfactory,
				"I+",
				"Температура 38, висип у вигляді плямок",
				"+380000000000",
				"Вул. Килина 13"
			));

			// ID = 2
			People.Add(new Person(
				"Манченко Вадим Віталійович",
				new DateTime(2022, 2, 4),
				new DateTime(2004, 9, 22),
				Gender.Male,
				HealthStatus.Good,
				"II+"
			));

			// ID = 2
			People.Add(new Person(
				"Манченко Вадим Віталійович",
				new DateTime(2022, 2, 4),
				new DateTime(2004, 9, 22),
				Gender.Male,
				HealthStatus.Good,
				"II+"
			));

			// ID = 3
			People.Add(new Person(
				"Шалаган Вікторія Сергіївна",
				new DateTime(2022, 2, 5),
				new DateTime(2004, 3, 22),
				Gender.Female,
				HealthStatus.Satisfactory,
				"III+"
			){ResidenceAddress = "Вул. Антошка 23"});

			// ID = 4
			People.Add(new Person(
				"Бабін Ілля Іванович",
				new DateTime(2022, 2, 6),
				new DateTime(2003, 9, 6),
				Gender.Male,
				HealthStatus.Excellent,
				"I+",
				"Біль у колінах",
				"+380010000000"
			));
		}


		private void CreatePatients() {
			Patients.Add(new Patient(People.First(e => e.FullName == "Воробйов Ярослав Іванович"), Diseases.First(e => e.CodeICD == "N30"), true));
			Patients.Add(new Patient(People.First(e => e.FullName == "Манченко Вадим Віталійович"), Diseases.First(e => e.CodeICD == "B01")));
			Patients.Add(new Patient(People.First(e => e.FullName == "Шалаган Вікторія Сергіївна"), Diseases.First(e => e.CodeICD == "J18"), false));
			Patients.Add(new Patient(People.First(e => e.FullName == "Бабін Ілля Іванович"), Diseases.First(e => e.CodeICD == "M13.9"), true));
			Patients.Add(new Patient(People.First(e => e.FullName == "Воробйов Ярослав Іванович"), Diseases.First(e => e.CodeICD == "J18"), true));
		}


		private void CreateDiseases() {
			Diseases.Add(new Disease("Вітряна віспа", "B01",
				"Висококонтагіозне інфекційне захворювання, спричинене вірусом вітряної віспи (герпесвірус 3); зазвичай вражає дітей, поширюється прямим контактом або дихальним шляхом через крапельки, і характеризується появою на шкірі та слизових оболонках послідовних посівів типових сверблячих везикулярних уражень, які легко розриваються і стають струпами; вітряна віспа відносно доброякісна у дітей, але може ускладнюватися пневмонією та енцефалітом у дорослих.\n" +
				"http://www.diseasesdatabase.com/ddb29118.htm \n" +
				"https://uk.wikipedia.org/wiki/%D0%92%D1%96%D1%82%D1%80%D1%8F%D0%BD%D0%B0_%D0%B2%D1%96%D1%81%D0%BF%D0%B0"));

			Diseases.Add(new Disease("Артрит", "M13.9",
				"Запальний процес у суглобі\n" +
				"https://www.novo.lviv.ua/media-center/artryt-i-artroz-jaka-riznycja-shcho-robyty-i-jak-likuvaty.html"));

			Diseases.Add(new Disease("Цистит", "N30",
				"Запалення сечового міхура внаслідок бактеріальних або небактеріальних причин. Цистит зазвичай супроводжується болісним сечовипусканням (дизурією), почастішанням, невідкладністю та надлобковим болем. http://www.diseasesdatabase.com/umlsdef.asp?glngUserChoice=29445"));

			Diseases.Add(new Disease("Пневмонія", "J18",
				"Запалення легень, яке відбувається перш за все у повітряних міхурцях, що називаються альвеолами. Виникає при інфікуванні бактеріями, значно рідше — вірусами та іншими мікроорганізмами, ураженні деякими медичними препаратами, ураженні легень при автоімунних захворюваннях тощо\n" +
				"Зазвичай при захворюванні спостерігають наступні симптоми: кашель, біль у грудях, гарячка, ускладнене дихання.Для діагностики застосовують рентгенографію легень і бактеріологічний посів мокротиння.\n" +
				"https://uk.wikipedia.org/wiki/%D0%9F%D0%BD%D0%B5%D0%B2%D0%BC%D0%BE%D0%BD%D1%96%D1%8F"));
		}
	}
}
