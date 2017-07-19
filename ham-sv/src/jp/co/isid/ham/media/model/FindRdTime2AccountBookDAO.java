package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj50RdStation;
import jp.co.isid.ham.integ.tbl.Mbj51Natural;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* 営業作業台帳ラジオタイムインポート情報検索DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/12/11 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
public class FindRdTime2AccountBookDAO extends AbstractSimpleRdbDao {

    /** インラインビュー */
    private static final String VW_RDPGMUSEDMATERIAL = "RDPGMUSEDMATERIAL";
    /** 20秒 */
    private static final String SECOND20 = "20";

    /** 検索条件 */
    private FindRdTime2AccountBookCondition _cond = null;

    /** 媒体区分(ラジオタイム) */
    private static final String MEDIA_RADIOTIME = "M05";

    /**
     * デフォルトコンストラクタ
     */
    public FindRdTime2AccountBookDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{ };
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return getRdProgramMaterial();
    }

    /**
     * ラジオ番組登録画面素材情報検索SQL文を返します
     *
     * @return String SQL文
     */
    private String getRdProgramMaterial() {

        StringBuffer sql = new StringBuffer();

        sql.append(" WITH " + VW_RDPGMUSEDMATERIAL + " AS (");
        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ + ",");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Mbj51Natural.NO + ",");
        sql.append(" " + Tbj17Content.CMCD + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);

        sql.append(" FROM");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ + ",");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRSUN + " ||");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + " ||");
        sql.append(" " + Tbj37RdProgram.ONAIRTUE + " ||");
        sql.append(" " + Tbj37RdProgram.ONAIRWED + " ||");
        sql.append(" " + Tbj37RdProgram.ONAIRTHU + " ||");
        sql.append(" " + Tbj37RdProgram.ONAIRFRI + " ||");
        sql.append(" " + Tbj37RdProgram.ONAIRSAT + " " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE + ",");
        sql.append(" " + Mbj51Natural.NO + ",");
        sql.append(" CASE " + Mbj51Natural.NO);
        sql.append(" WHEN 1 THEN " + Tbj38RdProgramMaterial.DAY01);
        sql.append(" WHEN 2 THEN " + Tbj38RdProgramMaterial.DAY02);
        sql.append(" WHEN 3 THEN " + Tbj38RdProgramMaterial.DAY03);
        sql.append(" WHEN 4 THEN " + Tbj38RdProgramMaterial.DAY04);
        sql.append(" WHEN 5 THEN " + Tbj38RdProgramMaterial.DAY05);
        sql.append(" WHEN 6 THEN " + Tbj38RdProgramMaterial.DAY06);
        sql.append(" WHEN 7 THEN " + Tbj38RdProgramMaterial.DAY07);
        sql.append(" WHEN 8 THEN " + Tbj38RdProgramMaterial.DAY08);
        sql.append(" WHEN 9 THEN " + Tbj38RdProgramMaterial.DAY09);
        sql.append(" WHEN 10 THEN " + Tbj38RdProgramMaterial.DAY10);
        sql.append(" WHEN 11 THEN " + Tbj38RdProgramMaterial.DAY11);
        sql.append(" WHEN 12 THEN " + Tbj38RdProgramMaterial.DAY12);
        sql.append(" WHEN 13 THEN " + Tbj38RdProgramMaterial.DAY13);
        sql.append(" WHEN 14 THEN " + Tbj38RdProgramMaterial.DAY14);
        sql.append(" WHEN 15 THEN " + Tbj38RdProgramMaterial.DAY15);
        sql.append(" WHEN 16 THEN " + Tbj38RdProgramMaterial.DAY16);
        sql.append(" WHEN 17 THEN " + Tbj38RdProgramMaterial.DAY17);
        sql.append(" WHEN 18 THEN " + Tbj38RdProgramMaterial.DAY18);
        sql.append(" WHEN 19 THEN " + Tbj38RdProgramMaterial.DAY19);
        sql.append(" WHEN 20 THEN " + Tbj38RdProgramMaterial.DAY20);
        sql.append(" WHEN 21 THEN " + Tbj38RdProgramMaterial.DAY21);
        sql.append(" WHEN 22 THEN " + Tbj38RdProgramMaterial.DAY22);
        sql.append(" WHEN 23 THEN " + Tbj38RdProgramMaterial.DAY23);
        sql.append(" WHEN 24 THEN " + Tbj38RdProgramMaterial.DAY24);
        sql.append(" WHEN 25 THEN " + Tbj38RdProgramMaterial.DAY25);
        sql.append(" WHEN 26 THEN " + Tbj38RdProgramMaterial.DAY26);
        sql.append(" WHEN 27 THEN " + Tbj38RdProgramMaterial.DAY27);
        sql.append(" WHEN 28 THEN " + Tbj38RdProgramMaterial.DAY28);
        sql.append(" WHEN 29 THEN " + Tbj38RdProgramMaterial.DAY29);
        sql.append(" WHEN 30 THEN " + Tbj38RdProgramMaterial.DAY30);
        sql.append(" WHEN 31 THEN " + Tbj38RdProgramMaterial.DAY31);
        sql.append(" END " + Tbj17Content.CMCD);

        sql.append(" FROM");
        sql.append(" " + Tbj37RdProgram.TBNAME + ",");
        sql.append(" " + Tbj38RdProgramMaterial.TBNAME);
        sql.append(" CROSS JOIN " + Mbj51Natural.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + " = " + _cond.getYearMonth().replace("/", "") + " AND");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + " = " + Tbj38RdProgramMaterial.RDSEQNO);
        sql.append(" )");
        sql.append(" WHERE");
        sql.append(" " + Tbj17Content.CMCD + " IS NOT NULL");
        sql.append(" )");

        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.KEIRETSUCD + ",");
        sql.append(" " + Mbj50RdStation.ABBREVIATION + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Mbj03Media.MEDIANM + ",");
        /* 2016/1/12 JASRAC不具合対応 HLC K.Soga Add Start */
//        sql.append(" TO_NUMBER(" + Tbj20SozaiKanriList.SECOND + ") " + Tbj20SozaiKanriList.SECOND + ",");
        /* 2016/1/12 JASRAC不具合対応 HLC K.Soga Add End */
        sql.append(" SUM(" + FindRdTime2AccountBookVO.CNT + " * " + Tbj20SozaiKanriList.SECOND + " / (" + Tbj20SozaiKanriList.SECOND + " / " + HAMConstants.SECOND20 + ")) " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" SUM(" + FindRdTime2AccountBookVO.CNT + ") " + FindRdTime2AccountBookVO.CNT + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);

        sql.append(" FROM");
        sql.append(" (");

        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.KEIRETSUCD + ",");
        sql.append(" " + Mbj50RdStation.ABBREVIATION + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Mbj03Media.MEDIANM + ",");
        sql.append(" COUNT(" + Tbj17Content.CMCD + ") " + FindRdTime2AccountBookVO.CNT + ",");
        sql.append(" TO_NUMBER(" + Tbj20SozaiKanriList.SECOND + ") " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);

        sql.append(" FROM");
        sql.append(" " + VW_RDPGMUSEDMATERIAL + ",");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + "");
        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN + " = '" + HAMConstants.NOKBN_RADIO + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " = " + Tbj18SozaiKanriData.CMCD + " AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_DATE('" + _cond.getYearMonth().replace("/", "") + "', 'YYYYMM')");
        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + "");
        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + " = '" + HAMConstants.NOKBN_RADIO + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NULL AND");
        sql.append(" TRIM(" + Tbj20SozaiKanriList.TEMPCMCD + ") = TRIM(" + Tbj36TempSozaiKanriData.TEMPCMCD + ") AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_DATE('" + _cond.getYearMonth().replace("/", "") + "', 'YYYYMM')");
        sql.append(" ) " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj50RdStation.TBNAME + ",");
        sql.append(" " + Mbj03Media.TBNAME);

        sql.append(" WHERE");
        sql.append(" TRIM(" + Tbj17Content.CMCD + ") =TRIM( " + Tbj20SozaiKanriList.CMCD + ") AND");
        sql.append(" " + Mbj03Media.MEDIACD + " = '" + MEDIA_RADIOTIME + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_DATE('" + _cond.getYearMonth().replace("/", "") + "', 'YYYYMM') AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD + " = " + Mbj50RdStation.RDCD);

        sql.append(" GROUP BY");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.KEIRETSUCD + ",");
        sql.append(" " + Mbj50RdStation.ABBREVIATION + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Mbj03Media.MEDIANM + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);
        sql.append(" )");
        sql.append(" WHERE");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + " = '01'");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.KEIRETSUCD + ",");
        sql.append(" " + Mbj50RdStation.ABBREVIATION + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Mbj03Media.MEDIANM + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);

        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.KEIRETSUCD + ",");
        sql.append(" " + Mbj50RdStation.ABBREVIATION + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Mbj03Media.MEDIANM + ",");
        sql.append(" SUM(" + FindRdTime2AccountBookVO.CNT + " * " + Tbj20SozaiKanriList.SECOND + ") " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" SUM(" + FindRdTime2AccountBookVO.CNT + ") " + FindRdTime2AccountBookVO.CNT + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);

        sql.append(" FROM");
        sql.append(" (");

        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.KEIRETSUCD + ",");
        sql.append(" " + Mbj50RdStation.ABBREVIATION + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Mbj03Media.MEDIANM + ",");
      sql.append(" COUNT(" + Tbj17Content.CMCD + ") * " + SECOND20 + " / TO_NUMBER(" + Tbj20SozaiKanriList.SECOND + ") " + FindRdTime2AccountBookVO.CNT + ",");
        sql.append(" TO_NUMBER(" + Tbj20SozaiKanriList.SECOND + ") " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);

        sql.append(" FROM");
        sql.append(" " + VW_RDPGMUSEDMATERIAL + ",");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + "");
        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN + " = '" + HAMConstants.NOKBN_RADIO + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " = " + Tbj18SozaiKanriData.CMCD + " AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_DATE('" + _cond.getYearMonth().replace("/", "") + "', 'YYYYMM')");
        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + "");
        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + " = '" + HAMConstants.NOKBN_RADIO + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NULL AND");
        sql.append(" TRIM(" + Tbj20SozaiKanriList.TEMPCMCD + ") = TRIM(" + Tbj36TempSozaiKanriData.TEMPCMCD + ") AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_DATE('" + _cond.getYearMonth().replace("/", "") + "', 'YYYYMM')");
        sql.append(" ) " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj50RdStation.TBNAME + ",");
        sql.append(" " + Mbj03Media.TBNAME);

        sql.append(" WHERE");
        sql.append(" TRIM(" + Tbj17Content.CMCD + ") =TRIM( " + Tbj20SozaiKanriList.CMCD + ") AND");
        sql.append(" " + Mbj03Media.MEDIACD + " = '" + MEDIA_RADIOTIME + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_DATE('" + _cond.getYearMonth().replace("/", "") + "', 'YYYYMM') AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD + " = " + Mbj50RdStation.RDCD);

        sql.append(" GROUP BY");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.KEIRETSUCD + ",");
        sql.append(" " + Mbj50RdStation.ABBREVIATION + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Mbj03Media.MEDIANM + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);
        sql.append(" )");

        sql.append(" WHERE");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + " = '02'");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.KEIRETSUCD + ",");
        sql.append(" " + Mbj50RdStation.ABBREVIATION + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Mbj03Media.MEDIANM + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);

        sql.append(" ORDER BY");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD);

        return sql.toString();
    }

    /**
     * 営業作業台帳ラジオタイムインポート情報検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindRdTime2AccountBookVO> findRdTime2AccountBookinfo(FindRdTime2AccountBookCondition cond) throws HAMException {

        super.setModel(new FindRdTime2AccountBookVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
