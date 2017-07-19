package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj51Natural;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.ham.integ.tbl.Tbj39RdProgramStation;
import jp.co.isid.ham.integ.tbl.Tbj40TempSozaiContent;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * JASRAC申請書(ラジオタイム)検索DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/18 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindJasracRadioTimeDAO extends AbstractRdbDao {

    /**
     * インラインビュー
     */
    /** ラジオ番組枠情報 */
    private static final String VW_RDPGMWAKU = "RDPGMWAKU";
    /** ラジオ番組素材 */
    private static final String VW_RDPGMMATERIAL = "RDPGMMATERIAL";
    /** 契約情報 */
    private static final String VW_CONTRACTINFO = "CONTRACTINFO";

    /** 件数 */
    private static final String CNT = "CNT";

    /** 検索条件 */
    private FindJasracRadioTimeCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindJasracRadioTimeDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
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

        StringBuffer sql = new StringBuffer();

        sql.append(" WITH");
        sql.append(" " + VW_RDPGMWAKU);
        sql.append(" AS");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Mbj51Natural.NO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ + ",");
        sql.append(" CASE " + Mbj51Natural.NO);
        sql.append(" WHEN 1 THEN " +Tbj38RdProgramMaterial.DAY01);
        sql.append(" WHEN 2 THEN " +Tbj38RdProgramMaterial.DAY02);
        sql.append(" WHEN 3 THEN " +Tbj38RdProgramMaterial.DAY03);
        sql.append(" WHEN 4 THEN " +Tbj38RdProgramMaterial.DAY04);
        sql.append(" WHEN 5 THEN " +Tbj38RdProgramMaterial.DAY05);
        sql.append(" WHEN 6 THEN " +Tbj38RdProgramMaterial.DAY06);
        sql.append(" WHEN 7 THEN " +Tbj38RdProgramMaterial.DAY07);
        sql.append(" WHEN 8 THEN " +Tbj38RdProgramMaterial.DAY08);
        sql.append(" WHEN 9 THEN " +Tbj38RdProgramMaterial.DAY09);
        sql.append(" WHEN 10 THEN " +Tbj38RdProgramMaterial.DAY10);
        sql.append(" WHEN 11 THEN " +Tbj38RdProgramMaterial.DAY11);
        sql.append(" WHEN 12 THEN " +Tbj38RdProgramMaterial.DAY12);
        sql.append(" WHEN 13 THEN " +Tbj38RdProgramMaterial.DAY13);
        sql.append(" WHEN 14 THEN " +Tbj38RdProgramMaterial.DAY14);
        sql.append(" WHEN 15 THEN " +Tbj38RdProgramMaterial.DAY15);
        sql.append(" WHEN 16 THEN " +Tbj38RdProgramMaterial.DAY16);
        sql.append(" WHEN 17 THEN " +Tbj38RdProgramMaterial.DAY17);
        sql.append(" WHEN 18 THEN " +Tbj38RdProgramMaterial.DAY18);
        sql.append(" WHEN 19 THEN " +Tbj38RdProgramMaterial.DAY19);
        sql.append(" WHEN 20 THEN " +Tbj38RdProgramMaterial.DAY20);
        sql.append(" WHEN 21 THEN " +Tbj38RdProgramMaterial.DAY21);
        sql.append(" WHEN 22 THEN " +Tbj38RdProgramMaterial.DAY22);
        sql.append(" WHEN 23 THEN " +Tbj38RdProgramMaterial.DAY23);
        sql.append(" WHEN 24 THEN " +Tbj38RdProgramMaterial.DAY24);
        sql.append(" WHEN 25 THEN " +Tbj38RdProgramMaterial.DAY25);
        sql.append(" WHEN 26 THEN " +Tbj38RdProgramMaterial.DAY26);
        sql.append(" WHEN 27 THEN " +Tbj38RdProgramMaterial.DAY27);
        sql.append(" WHEN 28 THEN " +Tbj38RdProgramMaterial.DAY28);
        sql.append(" WHEN 29 THEN " +Tbj38RdProgramMaterial.DAY29);
        sql.append(" WHEN 30 THEN " +Tbj38RdProgramMaterial.DAY30);
        sql.append(" WHEN 31 THEN " +Tbj38RdProgramMaterial.DAY31);
        sql.append(" END " + Tbj18SozaiKanriData.CMCD);

        sql.append(" FROM");
        sql.append(" " + Tbj38RdProgramMaterial.TBNAME);
        sql.append(" CROSS JOIN");
        sql.append(" " + Mbj51Natural.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + " BETWEEN '" + _cond.getStartYearMonth() + "' AND '" + _cond.getEndYearMonth() + "'");
        sql.append(" ) ,");

        sql.append(" " + VW_RDPGMMATERIAL);
        sql.append(" AS");
        sql.append(" (");

        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE + ",");
        sql.append(" COUNT(" + Tbj18SozaiKanriData.CMCD + ") " + CNT);

        sql.append(" FROM");
        sql.append(" " + VW_RDPGMWAKU + ",");
        sql.append(" " + Tbj37RdProgram.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " IS NOT NULL AND");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + " = " + Tbj37RdProgram.RDSEQNO);

        sql.append(" GROUP BY");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);

        sql.append(" UNION ALL");

        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj39RdProgramStation.STATIONCD + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE + ",");
        sql.append(" COUNT(" + Tbj18SozaiKanriData.CMCD + ")");

        sql.append(" FROM");
        sql.append(" " + VW_RDPGMWAKU + ",");
        sql.append(" " + Tbj37RdProgram.TBNAME + ",");
        sql.append(" " + Tbj39RdProgramStation.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " IS NOT NULL AND");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + " = " + Tbj37RdProgram.RDSEQNO + " AND");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + " = " + Tbj39RdProgramStation.RDSEQNO + " AND");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD + " <> " + Tbj39RdProgramStation.STATIONCD);

        sql.append(" GROUP BY");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj39RdProgramStation.STATIONCD + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE);
        sql.append(" ),");

        sql.append(" " + VW_CONTRACTINFO);
        sql.append(" AS");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND);

        sql.append(" FROM");
        sql.append(" (");

        sql.append(" SELECT");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND);
        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME + ",");
        sql.append(" " + Tbj17Content.TBNAME + ",");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME);

        sql.append(" WHERE");
        sql.append(" TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ", 'YYYYMM') BETWEEN '" + _cond.getStartYearMonth() + "' AND '" + _cond.getEndYearMonth() + "' AND");
        sql.append(" " + Tbj16ContractInfo.JASRACFLG + " = '" + HAMConstants.MUSIC_FOR_JASRAC + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' ' AND");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN + " = '" + HAMConstants.NOKBN_RADIO + "' AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + " = " + HAMConstants.CTRTKBN_MUSIC + " AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " = " + Tbj18SozaiKanriData.CMCD + " AND");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " = " + Tbj17Content.CMCD + " AND");
        sql.append(" " + Tbj17Content.CTRTKBN + " = " + Tbj16ContractInfo.CTRTKBN + " AND");
        sql.append(" " + Tbj17Content.CTRTNO + " = " + Tbj16ContractInfo.CTRTNO + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

        sql.append(" UNION ALL");

        sql.append(" SELECT");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND);

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
        sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME);

        sql.append(" WHERE");
        sql.append(" TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ", 'YYYYMM') BETWEEN '" + _cond.getStartYearMonth() + "' AND '" + _cond.getEndYearMonth() + "' AND");
        sql.append(" " + Tbj16ContractInfo.JASRACFLG + " = '" + HAMConstants.MUSIC_FOR_JASRAC + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG  + " = ' ' AND");
        sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + " = '" + HAMConstants.NOKBN_RADIO + "' AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + " = " + HAMConstants.CTRTKBN_MUSIC + " AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NULL AND");
        sql.append(" TRIM(" + Tbj20SozaiKanriList.TEMPCMCD + ") = TRIM(" + Tbj36TempSozaiKanriData.TEMPCMCD + ") AND");
        sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " = " + Tbj40TempSozaiContent.TEMPCMCD + " AND");
        sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " = " + Tbj16ContractInfo.CTRTKBN + " AND");
        sql.append(" " + Tbj40TempSozaiContent.CTRTNO + " = " + Tbj16ContractInfo.CTRTNO + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");
        sql.append(" )");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND);
        sql.append(" )");

        sql.append(" SELECT");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" SUM(" + CNT + " * 20 / TO_NUMBER(" + Tbj20SozaiKanriList.SECOND + ")) " + CNT);

        sql.append(" FROM");
        sql.append(" " + VW_RDPGMMATERIAL + ",");
        sql.append(" " + VW_CONTRACTINFO);

        sql.append(" WHERE");
        sql.append(" TRIM(" + Tbj18SozaiKanriData.CMCD + ") = TRIM(" + Tbj20SozaiKanriList.CMCD + ")");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND);

        sql.append(" ORDER BY");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD);

        return sql.toString();
    }

    /**
     * JASRAC申請書出力情報を検索し、データを取得する
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindJasracRadioTimeVO> selectVO(FindJasracRadioTimeCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindJasracRadioTimeVO());

        try
        {
            _cond = condition;
            return (List<FindJasracRadioTimeVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
