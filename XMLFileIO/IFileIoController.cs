using PatientsInfo.Data;

namespace FileIO {
  /// <summary>
  /// Інтерфейс для взаємодії з <see cref="XmlFileIoController"/> та <see cref="BinarySerializationController"/>
  /// 
  /// </summary>
    public interface IFileIoController {
        string FileExtension { get; set; }

        void Load(DataSet dataSet, string fileName);
        void Save(DataSet dataSet, string fileName);
    }
}