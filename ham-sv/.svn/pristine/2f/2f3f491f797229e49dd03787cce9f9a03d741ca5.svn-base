package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj51Natural;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.ham.integ.tbl.Tbj40TempSozaiContent;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * JASRAC請求明細書(ラジオタイム)検索DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/19 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindJasracRadioTimeBillDAO extends AbstractRdbDao {

    /** 件数 */
    private static final String CNT = "CNT";

    /** 検索条件 */
    private FindJasracRadioTimeBillCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindJasracRadioTimeBillDAO() {
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

        sql.append(" WITH RDPROGRAMMATERIAL AS (");
        sql.append(" SELECT");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE + ",");
        sql.append(" " + Mbj51Natural.NO + ",");
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
        sql.append(" " + Tbj37RdProgram.TBNAME + ",");
        sql.append(" " + Tbj38RdProgramMaterial.TBNAME);
        sql.append(" CROSS JOIN");
        sql.append(" " + Mbj51Natural.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + " BETWEEN '" + _condition.getStartYearMonth() + "' AND '" + _condition.getEndYearMonth() + "' AND");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + " = " + Tbj38RdProgramMaterial.RDSEQNO);
        sql.append(" )");

        sql.append(" SELECT");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj16ContractInfo.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" COUNT(DISTINCT " + Mbj51Natural.NO + ")" + CNT + ",");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND);

        sql.append(" FROM");
        sql.append(" RDPROGRAMMATERIAL,");
        sql.append(" " + Tbj17Content.TBNAME + ",");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " IS NOT NULL AND");
        sql.append(" " + Tbj17Content.CTRTKBN + " = " + HAMConstants.CTRTKBN_MUSIC + " AND");
        sql.append(" " + Tbj16ContractInfo.JASRACFLG + " = '" + HAMConstants.MUSIC_FOR_JASRAC + "' AND");   //JASRAC対象
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " = " + Tbj20SozaiKanriList.CMCD + " AND");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " = " + Tbj17Content.CMCD + " AND");
        sql.append(" " + Tbj17Content.CTRTKBN + " = " + Tbj16ContractInfo.CTRTKBN + " AND");
        sql.append(" " + Tbj17Content.CTRTNO + " = " + Tbj16ContractInfo.CTRTNO + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ", 'YYYYMM') = " + Tbj38RdProgramMaterial.YEARMONTH);

        sql.append(" GROUP BY");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj16ContractInfo.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND);

        sql.append(" UNION ALL");

        sql.append(" SELECT");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj16ContractInfo.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" COUNT(DISTINCT " + Mbj51Natural.NO + ")" + CNT + ",");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND);

        sql.append(" FROM");
        sql.append(" RDPROGRAMMATERIAL,");
        sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " IS NOT NULL AND");
        sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " = " + HAMConstants.CTRTKBN_MUSIC + " AND");
        sql.append(" " + Tbj16ContractInfo.JASRACFLG + " = '" + HAMConstants.MUSIC_FOR_JASRAC + "' AND");   //JASRAC対象
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NULL AND");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " = " + Tbj20SozaiKanriList.TEMPCMCD + " AND");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " = " + Tbj40TempSozaiContent.TEMPCMCD + " AND");
        sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " = " + Tbj16ContractInfo.CTRTKBN + " AND");
        sql.append(" " + Tbj40TempSozaiContent.CTRTNO + " = " + Tbj16ContractInfo.CTRTNO + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ", 'YYYYMM') = " + Tbj38RdProgramMaterial.YEARMONTH);

        sql.append(" GROUP BY");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj16ContractInfo.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND);

        sql.append(" ORDER BY");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj37RdProgram.RDSEQNO);

        return sql.toString();
    }

    /**
     * JASRAC申請書出力情報を検索し、データを取得する
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindJasracRadioTimeBillVO> selectVO(FindJasracRadioTimeBillCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindJasracRadioTimeBillVO());

        try
        {
            _condition = condition;
            return (List<FindJasracRadioTimeBillVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
