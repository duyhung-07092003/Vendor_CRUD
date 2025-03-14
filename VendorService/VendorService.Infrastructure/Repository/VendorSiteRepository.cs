using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorService.Domain.Models;
using VendorService.Domain.AutoMapper;

namespace VendorService.Infrastructure.Repository
{
    public class VendorSiteRepository
    {
        private readonly string _connectionString;

        public VendorSiteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection()
        {
            return new OracleConnection(_connectionString);
        }
        public async Task<IEnumerable<VendorSiteViewModel>> GetAllVendorSites()
        {
            using var connection = CreateConnection();
            string query = @"
                SELECT
                    ORG_ID AS OrgId,
                    VENDOR_ID AS VendorId,
                    VENDOR_SITE_ID AS VendorSiteId,
                    VENDOR_SITE_CODE AS VendorSiteCode,
                    VENDOR_SITE_CODE_ALT AS VendorSiteCodeAlt,
                    ADDRESS_LINE1 AS AddressLine1,
                    ADDRESS_LINE2 AS AddressLine2,
                    ADDRESS_LINE3 AS AddressLine3,
                    ADDRESS_LINE4 AS AddressLine4,
                    ADDRESS_LINES_ALT AS AddressLinesAlt,
                    CITY AS City,
                    DISTRICT AS District,
                    WARD AS Ward,
                    BANK_ACCOUNT_NUM AS BankAccountNum,
                    BANK_ACCOUNT_TYPE AS BankAccountType,
                    BANK_BRANCH_TYPE AS BankBranchType,
                    BANK_ACCOUNT_NAME AS BankAccountName,
                    ACCTS_PAY_CCID AS AcctsPayCcid,
                    PREPAY_CCID AS PrepayCcid,
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
                FROM TBL_VENDOR_SITES
            ";
            return await connection.QueryAsync<VendorSiteViewModel>(query);
        }

        public async Task<VendorSiteViewModel> GetVendorSitesById(string vendorSiteId)
        {
            using var connection = CreateConnection();
            string query = @"
                SELECT
                    ORG_ID AS OrgId,
                    VENDOR_ID AS VendorId,
                    VENDOR_SITE_ID AS VendorSiteId,
                    VENDOR_SITE_CODE AS VendorSiteCode,
                    VENDOR_SITE_CODE_ALT AS VendorSiteCodeAlt,
                    ADDRESS_LINE1 AS AddressLine1,
                    ADDRESS_LINE2 AS AddressLine2,
                    ADDRESS_LINE3 AS AddressLine3,
                    ADDRESS_LINE4 AS AddressLine4,
                    ADDRESS_LINES_ALT AS AddressLinesAlt,
                    CITY AS City,
                    DISTRICT AS District,
                    WARD AS Ward,
                    BANK_ACCOUNT_NUM AS BankAccountNum,
                    BANK_ACCOUNT_TYPE AS BankAccountType,
                    BANK_BRANCH_TYPE AS BankBranchType,
                    BANK_ACCOUNT_NAME AS BankAccountName,
                    ACCTS_PAY_CCID AS AcctsPayCcid,
                    PREPAY_CCID AS PrepayCcid,
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
                FROM TBL_VENDOR_SITES
                WHERE VENDOR_SITE_ID = :VendorSiteId
            ";

            return await connection.QueryFirstOrDefaultAsync<VendorSiteViewModel>(query, new { VendorSiteId = vendorSiteId });
        }

        public async Task<int> CreateVendorSites(VendorSiteViewModel vendorSite)
        {
            using var connection = CreateConnection();
            string query = @"
                INSERT INTO tbl_vendor_sites 
                (ORG_ID, VENDOR_ID, VENDOR_SITE_ID, VENDOR_SITE_CODE, VENDOR_SITE_CODE_ALT, 
                 ADDRESS_LINE1, ADDRESS_LINE2, ADDRESS_LINE3, ADDRESS_LINE4, ADDRESS_LINES_ALT, 
                 CITY, district, ward, BANK_ACCOUNT_NUM, BANK_ACCOUNT_TYPE, 
                 BANK_BRANCH_TYPE, BANK_ACCOUNT_NAME, ACCTS_PAY_CCID, PREPAY_CCID, 
                 Attribute1, Attribute2, Attribute3, Attribute4, Attribute5, 
                 Attribute6, Attribute7, Attribute8, Attribute9, Attribute10, 
                 Attribute11, Attribute12, Attribute13, Attribute14, Attribute15, 
                 Last_Updated_By, Last_Update_Date, Created_By, Creation_Date) 
                VALUES 
                (:OrgId, :VendorId, :VendorSiteId, :VendorSiteCode, :VendorSiteCodeAlt, 
                 :AddressLine1, :AddressLine2, :AddressLine3, :AddressLine4, :AddressLinesAlt, 
                 :City, :District, :Ward, :BankAccountNum, :BankAccountType, 
                 :BankBranchType, :BankAccountName, :AcctsPayCcid, :PrepayCcid, 
                 :Attribute1, :Attribute2, :Attribute3, :Attribute4, :Attribute5, 
                 :Attribute6, :Attribute7, :Attribute8, :Attribute9, :Attribute10, 
                 :Attribute11, :Attribute12, :Attribute13, :Attribute14, :Attribute15, 
                 :LastUpdatedBy, SYSDATE, :CreatedBy, SYSDATE)";

            return await connection.ExecuteAsync(query, vendorSite);
        }

        public async Task<int> UpdateVendorSites(VendorSiteViewModel vendorSite)
        {
            using var connection = CreateConnection();
            string query = @"
                UPDATE tbl_vendor_sites SET 
                    ORG_ID = :OrgId, 
                    VENDOR_ID = :VendorId, 
                    VENDOR_SITE_CODE = :VendorSiteCode, 
                    VENDOR_SITE_CODE_ALT = :VendorSiteCodeAlt, 
                    ADDRESS_LINE1 = :AddressLine1, 
                    ADDRESS_LINE2 = :AddressLine2, 
                    ADDRESS_LINE3 = :AddressLine3, 
                    ADDRESS_LINE4 = :AddressLine4, 
                    ADDRESS_LINES_ALT = :AddressLinesAlt, 
                    CITY = :City, 
                    district = :District, 
                    ward = :Ward, 
                    BANK_ACCOUNT_NUM = :BankAccountNum, 
                    BANK_ACCOUNT_TYPE = :BankAccountType, 
                    BANK_BRANCH_TYPE = :BankBranchType, 
                    BANK_ACCOUNT_NAME = :BankAccountName, 
                    ACCTS_PAY_CCID = :AcctsPayCcid, 
                    PREPAY_CCID = :PrepayCcid, 
                    Attribute1 = :Attribute1, 
                    Attribute2 = :Attribute2, 
                    Attribute3 = :Attribute3, 
                    Attribute4 = :Attribute4, 
                    Attribute5 = :Attribute5, 
                    Attribute6 = :Attribute6, 
                    Attribute7 = :Attribute7, 
                    Attribute8 = :Attribute8, 
                    Attribute9 = :Attribute9, 
                    Attribute10 = :Attribute10, 
                    Attribute11 = :Attribute11, 
                    Attribute12 = :Attribute12, 
                    Attribute13 = :Attribute13, 
                    Attribute14 = :Attribute14, 
                    Attribute15 = :Attribute15, 
                    Last_Updated_By = :LastUpdatedBy, 
                    Last_Update_Date = SYSDATE
                WHERE VENDOR_SITE_ID = :VendorSiteId";

            return await connection.ExecuteAsync(query, vendorSite);
        }

        public async Task<int> DeleteVendorSites(string vendorSiteId)
        {
            using var connection = CreateConnection();
            string query = "DELETE FROM tbl_vendor_sites WHERE VENDOR_SITE_ID = :VendorSiteId";
            return await connection.ExecuteAsync(query, new { VendorSiteId = vendorSiteId });
        }
    }
}
    

