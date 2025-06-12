using System.Collections.Generic;
using EmissionDataRecordService.Model;

namespace EmissionDataRecordService.Service
{
   
    public interface IEmissionDataService
    {
        List<EmissionDataRecord> GetAllEmissionDataRecords();
        List<EmissionDataRecord> GetByMaterialNo(string materialNo);
        List<EmissionDataRecord> GetByCountryCode(string isoCode);
        EmissionDataRecord AddNewEmission(EmissionDataRecord emissionDataRecord);
        EmissionDataRecord UpdateByEmission(string materialNo, EmissionDataRecord emissionDataRecord);
    }
}
