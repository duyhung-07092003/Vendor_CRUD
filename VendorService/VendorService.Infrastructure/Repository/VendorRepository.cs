using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using VendorService.Domain.Models;
using VendorService.Domain.AutoMapper;

namespace VendorService.Infrastructure.Repository
{
    public class VendorRepository
    {
        private readonly string _connectionString;

        public VendorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection()
        {
            return new OracleConnection(_connectionString);
        }

        // Lấy tất cả 
        public async Task<IEnumerable<VendorViewModel>> GetAllVendors()
        {
            using (var connection = CreateConnection())
            {
                string query = @"
                    SELECT 
                        SET_OF_BOOKS_ID AS SetOfBooksId,
                        VENDOR_ID AS VendorId,
                        VENDOR_NAME AS VendorName,
                        SEGMENT1 AS Segment1,
                        ENABLED_FLAG AS EnabledFlag,
                        START_DATE_ACTIVE AS StartDateActive,
                        END_DATE_ACTIVE AS EndDateActive,
                        VENDOR_TYPE_LOOKUP_CODE AS VendorTypeLookupCode,
                        EMPLOYEE_ID AS EmployeeId,
                        VENDOR_NAME_ALT AS VendorNameAlt,
                        VAT_REGISTRATION_NUM AS VatRegistrationNum,
                        STATUS AS Status,
                        ATTRIBUTE1 AS Attribute1,
                        ATTRIBUTE2 AS Attribute2,
                        ATTRIBUTE3 AS Attribute3,
                        ATTRIBUTE4 AS Attribute4,
                        ATTRIBUTE5 AS Attribute5,
                        ATTRIBUTE6 AS Attribute6,
                        ATTRIBUTE7 AS Attribute7,
                        ATTRIBUTE8 AS Attribute8,
                        ATTRIBUTE9 AS Attribute9,
                        ATTRIBUTE10 AS Attribute10,
                        ATTRIBUTE11 AS Attribute11,
                        ATTRIBUTE12 AS Attribute12,
                        ATTRIBUTE13 AS Attribute13,
                        ATTRIBUTE14 AS Attribute14,
                        ATTRIBUTE15 AS Attribute15,
                        LAST_UPDATED_BY AS LastUpdatedBy,
                        LAST_UPDATE_DATE AS LastUpdateDate,
                        CREATED_BY AS CreatedBy,
                        CREATION_DATE AS CreationDate
                    FROM TBL_VENDORS";
                return await connection.QueryAsync<VendorViewModel>(query);
            }
        }

        // Lấy theo ID
        public async Task<VendorViewModel> GetVendorById(decimal vendorId)
        {
            using (var connection = CreateConnection())
            {
                string query = @"
                    SELECT 
                        VENDOR_ID AS VendorId,
                        VENDOR_NAME AS VendorName,
                        SEGMENT1 AS Segment1,
                        ENABLED_FLAG AS EnabledFlag,
                        START_DATE_ACTIVE AS StartDateActive,
                        END_DATE_ACTIVE AS EndDateActive,
                        VENDOR_TYPE_LOOKUP_CODE AS VendorTypeLookupCode,
                        EMPLOYEE_ID AS EmployeeId,
                        VENDOR_NAME_ALT AS VendorNameAlt,
                        VAT_REGISTRATION_NUM AS VatRegistrationNum,
                        STATUS AS Status,
                        ATTRIBUTE1 AS Attribute1,
                        ATTRIBUTE2 AS Attribute2,
                        ATTRIBUTE3 AS Attribute3,
                        ATTRIBUTE4 AS Attribute4,
                        ATTRIBUTE5 AS Attribute5,
                        ATTRIBUTE6 AS Attribute6,
                        ATTRIBUTE7 AS Attribute7,
                        ATTRIBUTE8 AS Attribute8,
                        ATTRIBUTE9 AS Attribute9,
                        ATTRIBUTE10 AS Attribute10,
                        ATTRIBUTE11 AS Attribute11,
                        ATTRIBUTE12 AS Attribute12,
                        ATTRIBUTE13 AS Attribute13,
                        ATTRIBUTE14 AS Attribute14,
                        ATTRIBUTE15 AS Attribute15,
                        LAST_UPDATED_BY AS LastUpdatedBy,
                        LAST_UPDATE_DATE AS LastUpdateDate,
                        CREATED_BY AS CreatedBy,
                        CREATION_DATE AS CreationDate,
                        SET_OF_BOOKS_ID AS SetOfBooksId
                    FROM TBL_VENDORS
                    WHERE VENDOR_ID = :VENDOR_ID";

                return await connection.QueryFirstOrDefaultAsync<VendorViewModel>(
                    query,
                    new { VENDOR_ID = vendorId }
                );
            }
        }

        // Thêm mới Vendor
        public async Task<int> CreateVendor(VendorViewModel vendor)
        {
            using (var connection = CreateConnection())
            {
                string query = @"
                    INSERT INTO TBL_Vendors 
                    (SET_OF_BOOKS_ID, VENDOR_ID, VENDOR_NAME, SEGMENT1, ENABLED_FLAG, START_DATE_ACTIVE, END_DATE_ACTIVE, 
                     VENDOR_TYPE_LOOKUP_CODE, EMPLOYEE_ID, VENDOR_NAME_ALT, VAT_REGISTRATION_NUM, status, 
                     Attribute1, Attribute2, Last_Updated_By, Last_Update_Date, Created_By, Creation_Date)
                    VALUES 
                    (:SetOfBooksId, :VendorId, :VendorName, :Segment1, :EnabledFlag, :StartDateActive, :EndDateActive, 
                     :VendorTypeLookupCode, :EmployeeId, :VendorNameAlt, :VatRegistrationNum, :Status, 
                     :Attribute1, :Attribute2, :LastUpdatedBy, SYSDATE, :CreatedBy, SYSDATE)";

                return await connection.ExecuteAsync(query, vendor);
            }
        }

        // Cập nhật
        public async Task<int> UpdateVendor(VendorViewModel vendor)
        {
            using (var connection = CreateConnection())
            {
                string query = @"
                    UPDATE TBL_Vendors 
                    SET 
                        SET_OF_BOOKS_ID = :SetOfBooksId,
                        VENDOR_NAME = :VendorName,
                        SEGMENT1 = :Segment1,
                        ENABLED_FLAG = :EnabledFlag,
                        START_DATE_ACTIVE = :StartDateActive,
                        END_DATE_ACTIVE = :EndDateActive,
                        VENDOR_TYPE_LOOKUP_CODE = :VendorTypeLookupCode,
                        EMPLOYEE_ID = :EmployeeId,
                        VENDOR_NAME_ALT = :VendorNameAlt,
                        VAT_REGISTRATION_NUM = :VatRegistrationNum,
                        status = :Status,
                        Attribute1 = :Attribute1,
                        Attribute2 = :Attribute2,
                        Last_Updated_By = :LastUpdatedBy,
                        Last_Update_Date = SYSDATE
                    WHERE VENDOR_ID = :VendorId";

                return await connection.ExecuteAsync(query, vendor);
            }
        }

        // Xóa theo ID
        public async Task<int> DeleteVendor(decimal vendorId)
        {
            using (var connection = CreateConnection())
            {
                string query = "DELETE FROM TBL_Vendors WHERE VENDOR_ID = :VendorId";
                return await connection.ExecuteAsync(query, new { VendorId = vendorId });
            }
        }
    }
}