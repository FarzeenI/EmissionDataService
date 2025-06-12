using EmissionDataRecordService.Data;
using EmissionDataRecordService.Model;

namespace EmissionDataRecordService.Repository
{
    public class EmissionDataRepository : IEmissionRepositoryInterface
    {
        private readonly EmissionDbContext _context;    
        public EmissionDataRepository(EmissionDbContext context)
        {
            _context = context;
        }
        public List<EmissionDataRecord> GetAllEmissions()
        {
            return _context.EmissionDataRecords.ToList();
        }

        public List<EmissionDataRecord> GetCountryCode(string isoCode)
        {
           return _context.EmissionDataRecords
                .Where(e => e.Iso_Country_Code == isoCode)
                .ToList();
        }

        public List<EmissionDataRecord> GetMaterialNo(string materialNo)
        {
            return _context.EmissionDataRecords
                 .Where(e => e.Material_Number == materialNo)
                 .ToList();
        }
        public EmissionDataRecord AddEmission(EmissionDataRecord emissionDataRecord)
        {
            _context.EmissionDataRecords.Add(emissionDataRecord);
            _context.SaveChanges();
            return emissionDataRecord;
        }

        public EmissionDataRecord UpdateEmission(string materialNo, EmissionDataRecord emissionDataRecord)
        {
            var existingRecord = _context.EmissionDataRecords
                .FirstOrDefault(e => e.Material_Number == materialNo);

            if (existingRecord == null)
            {
                throw new KeyNotFoundException($"Emission record with Material Number '{materialNo}' not found.");
            }
            // Update all properties
            existingRecord.Category_ID = emissionDataRecord.Category_ID;
            existingRecord.Category_Name = emissionDataRecord.Category_Name;
            existingRecord.Source_Create_Timestamp = emissionDataRecord.Source_Create_Timestamp;
            existingRecord.Logical_Deletion_Indicator = emissionDataRecord.Logical_Deletion_Indicator;
            existingRecord.Production_Rounded_KgCO2 = emissionDataRecord.Production_Rounded_KgCO2;
            existingRecord.Transport_Rounded_KgCO2 = emissionDataRecord.Transport_Rounded_KgCO2;
            existingRecord.Energy_Use_Rounded_KgCO2 = emissionDataRecord.Energy_Use_Rounded_KgCO2;
            existingRecord.Eol_Rounded_KgCO2 = emissionDataRecord.Eol_Rounded_KgCO2;
            existingRecord.Cartridges_Rounded_KgCO2 = emissionDataRecord.Cartridges_Rounded_KgCO2;
            existingRecord.Consumables_Rounded_KgCO2 = emissionDataRecord.Consumables_Rounded_KgCO2;
            existingRecord.Paper_Rounded_KgCO2 = emissionDataRecord.Paper_Rounded_KgCO2;
            existingRecord.Total_Rounded_KgCO2 = emissionDataRecord.Total_Rounded_KgCO2;
            existingRecord.Total_Lower_Bounds_KgCO2 = emissionDataRecord.Total_Lower_Bounds_KgCO2;
            existingRecord.Total_Upper_Bounds_KgCO2 = emissionDataRecord.Total_Upper_Bounds_KgCO2;
            existingRecord.Source_System_Update_Timestamp = emissionDataRecord.Source_System_Update_Timestamp;
            existingRecord.Insert_Gmt_Timestamp = emissionDataRecord.Insert_Gmt_Timestamp;
            existingRecord.Material_Hierarchy_Model_Node_Name = emissionDataRecord.Material_Hierarchy_Model_Node_Name;
            existingRecord.Material_Hierarchy_Parent_Hierarchy_Identifier = emissionDataRecord.Material_Hierarchy_Parent_Hierarchy_Identifier;

            _context.SaveChanges();
            return existingRecord;
        }

    }
}
