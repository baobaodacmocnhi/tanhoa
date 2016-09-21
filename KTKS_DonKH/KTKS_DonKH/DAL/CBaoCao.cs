using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KTKS_DonKH.DAL
{
    class CBaoCao:CDAL
    {
        /// <summary>
        /// Tiến trình nhận đơn & xử lý đơn(bao gồm đơn đã nhận trước đó) từ ngày đến ngày
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable TienTrinhXuLyDon(DateTime FromDate,DateTime ToDate)
        {
            string sql = "declare @FromDate as date;"
                            + " declare @ToDate as date;"
                            + " set @FromDate='" + FromDate.ToString("yyyy-MM-dd") + "';"
                            + " set @ToDate='" + ToDate.ToString("yyyy-MM-dd") + "';"
                            + " select MAX(TongDonKH) as DonKH,"
                            + " 		MAX(TongDonTXL) as DonTXL,"
                            + " 		MAX(TongDCHD) as DCHD,"
                            + " 		MAX(TongDCBD) as DCBD,"
                            + " 		MAX(TongCTDB) as CTDB,"
                            + " 		MAX(TongCHDB) as CHDB,"
                            + " 		MAX(TongTTTL) as TTTL from"
                            + " ("
                            + " select COUNT(*) as TongDonKH,0 as TongDonTXL,0 as TongDCHD,0 as TongDCBD,0 as TongCTDB,0 as TongCHDB,0 as TongTTTL from DonKH where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate"
                            + " union"
                            + " select 0 as TongDonKH,COUNT(*) as TongDonTXL,0 as TongDCHD,0 as TongDCBD,0 as TongCTDB,0 as TongCHDB,0 as TongTTTL from DonTXL where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate"
                            + " union"
                            + " select 0 as TongDonKH,0 as TongDonTXL,COUNT(*) as TongDCHD,0 as TongDCBD,0 as TongCTDB,0 as TongCHDB,0 as TongTTTL from DCBD a,CTDCHD b where a.MaDCBD=b.MaDCBD and CAST(b.CreateDate as date)>=@FromDate and CAST(b.CreateDate as date)<=@ToDate"
                            + " union"
                            + " select 0 as TongDonKH,0 as TongDonTXL,0 as TongDCHD,COUNT(*) as TongDCBD,0 as TongCTDB,0 as TongCHDB,0 as TongTTTL from DCBD a,CTDCBD b where a.MaDCBD=b.MaDCBD and CAST(b.CreateDate as date)>=@FromDate and CAST(b.CreateDate as date)<=@ToDate"
                            + " union"
                            + " select 0 as TongDonKH,0 as TongDonTXL,0 as TongDCHD,0 as TongDCBD,COUNT(*) as TongCTDB,0 as TongCHDB,0 as TongTTTL from CHDB a,CTCTDB b where a.MaCHDB=b.MaCHDB and CAST(b.CreateDate as date)>=@FromDate and CAST(b.CreateDate as date)<=@ToDate"
                            + " union"
                            + " select 0 as TongDonKH,0 as TongDonTXL,0 as TongDCHD,0 as TongDCBD,0 as TongCTDB,COUNT(*) as TongCHDB,0 as TongTTTL from CHDB a,CTCHDB b where a.MaCHDB=b.MaCHDB and CAST(b.CreateDate as date)>=@FromDate and CAST(b.CreateDate as date)<=@ToDate"
                            + " union"
                            + " select 0 as TongDonKH,0 as TongDonTXL,0 as TongDCHD,0 as TongDCBD,0 as TongCTDB,0 as TongCHDB,COUNT(*) as TongTTTL from TTTL a,CTTTTL b where a.MaTTTL=b.MaTTTL and CAST(b.CreateDate as date)>=@FromDate and CAST(b.CreateDate as date)<=@ToDate"
                            + " ) t1";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        /// <summary>
        /// Tiến trình nhận đơn & xử lý đơn đã nhận từ ngày đến ngày
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable TienTrinhXuLyDon_B(DateTime FromDate, DateTime ToDate)
        {
            string sql = "declare @FromDate as date;"
                            + " declare @ToDate as date;"
                            + " set @FromDate='" + FromDate.ToString("yyyy-MM-dd") + "';"
                            + " set @ToDate='" + ToDate.ToString("yyyy-MM-dd") + "';"
                            + " select MAX(TongDonKH) as DonKH,"
                            + " 		MAX(TongDonTXL) as DonTXL,"
                            + " 		MAX(TongDCHD) as DCHD,"
                            + " 		MAX(TongDCBD) as DCBD,"
                            + " 		MAX(TongCTDB) as CTDB,"
                            + " 		MAX(TongCHDB) as CHDB,"
                            + " 		MAX(TongTTTL) as TTTL from"
                            + " ("
                            + " select COUNT(*) as TongDonKH,0 as TongDonTXL,0 as TongDCHD,0 as TongDCBD,0 as TongCTDB,0 as TongCHDB,0 as TongTTTL from DonKH where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate"
                            + " and (MaDon in (select MaDon from KTXM) or MaDon in (select MaDon from DCBD) or MaDon in (select MaDon from CHDB) or MaDon in (select MaDon from TTTL))"
                            + " union"
                            + " select 0 as TongDonKH,COUNT(*) as TongDonTXL,0 as TongDCHD,0 as TongDCBD,0 as TongCTDB,0 as TongCHDB,0 as TongTTTL from DonTXL where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate"
                            + " and (MaDon in (select MaDonTXL from KTXM) or MaDon in (select MaDonTXL from BamChi) or MaDon in (select MaDonTXL from DCBD) or MaDon in (select MaDonTXL from CHDB) or MaDon in (select MaDonTXL from TTTL))"
                            + " union"
                            + " select 0 as TongDonKH,0 as TongDonTXL,COUNT(*) as TongDCHD,0 as TongDCBD,0 as TongCTDB,0 as TongCHDB,0 as TongTTTL from DCBD a,CTDCHD b where a.MaDCBD=b.MaDCBD and CAST(b.CreateDate as date)>=@FromDate and CAST(b.CreateDate as date)<=@ToDate"
                            + " and (MaDon in (select MaDon from DonKH where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate) or MaDonTXL in (select MaDon from DonTXL where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate))"
                            + " union"
                            + " select 0 as TongDonKH,0 as TongDonTXL,0 as TongDCHD,COUNT(*) as TongDCBD,0 as TongCTDB,0 as TongCHDB,0 as TongTTTL from DCBD a,CTDCBD b where a.MaDCBD=b.MaDCBD and CAST(b.CreateDate as date)>=@FromDate and CAST(b.CreateDate as date)<=@ToDate"
                            + " and (MaDon in (select MaDon from DonKH where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate) or MaDonTXL in (select MaDon from DonTXL where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate))"
                            + " union"
                            + " select 0 as TongDonKH,0 as TongDonTXL,0 as TongDCHD,0 as TongDCBD,COUNT(*) as TongCTDB,0 as TongCHDB,0 as TongTTTL from CHDB a,CTCTDB b where a.MaCHDB=b.MaCHDB and CAST(b.CreateDate as date)>=@FromDate and CAST(b.CreateDate as date)<=@ToDate"
                            + " and (MaDon in (select MaDon from DonKH where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate) or MaDonTXL in (select MaDon from DonTXL where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate))"
                            + " union"
                            + " select 0 as TongDonKH,0 as TongDonTXL,0 as TongDCHD,0 as TongDCBD,0 as TongCTDB,COUNT(*) as TongCHDB,0 as TongTTTL from CHDB a,CTCHDB b where a.MaCHDB=b.MaCHDB and CAST(b.CreateDate as date)>=@FromDate and CAST(b.CreateDate as date)<=@ToDate"
                            + " and (MaDon in (select MaDon from DonKH where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate) or MaDonTXL in (select MaDon from DonTXL where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate))"
                            + " union"
                            + " select 0 as TongDonKH,0 as TongDonTXL,0 as TongDCHD,0 as TongDCBD,0 as TongCTDB,0 as TongCHDB,COUNT(*) as TongTTTL from TTTL a,CTTTTL b where a.MaTTTL=b.MaTTTL and CAST(b.CreateDate as date)>=@FromDate and CAST(b.CreateDate as date)<=@ToDate"
                            + " and (MaDon in (select MaDon from DonKH where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate) or MaDonTXL in (select MaDon from DonTXL where CAST(CreateDate as date)>=@FromDate and CAST(CreateDate as date)<=@ToDate))"
                            + " ) t1";

            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

    }
}
