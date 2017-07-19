package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj37RdProgramCondition;
import jp.co.isid.ham.common.model.Tbj37RdProgramVO;
import jp.co.isid.ham.integ.tbl.Mbj51Natural;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* ラジオ番組一覧画面情報検索DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
public class FindRdProgramListDAO extends AbstractSimpleRdbDao {

    /** 件数 */
    private static final String CNT = "CNT";

    /**
     * インラインビュー
     */
    /** ラジオ番組素材情報 */
    private static final String VW_RDPGMWAKU = "RDPGMWAKU";

    /**
     * デフォルトコンストラクタ
     */
    public FindRdProgramListDAO() {
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

        sql.append(" WITH");
        sql.append(" " + VW_RDPGMWAKU);
        sql.append(" AS");
        sql.append(" (");

        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" COUNT(" + Tbj18SozaiKanriData.CMCD + ") " + CNT);
        sql.append(" FROM");
        sql.append(" (");

        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Mbj51Natural.NO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ + ",");
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
        sql.append(" END " + Tbj18SozaiKanriData.CMCD);

        sql.append(" FROM");
        sql.append(" " + Tbj38RdProgramMaterial.TBNAME);
        sql.append(" CROSS JOIN");
        sql.append(" " + Mbj51Natural.TBNAME);
        sql.append(" )");
        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " IS NOT NULL");
        sql.append(" GROUP BY");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO);
        sql.append(" )");

        sql.append(" SELECT");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + ",");
        sql.append(" " + Tbj37RdProgram.PHASE + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Tbj37RdProgram.RSDIV + ",");
        sql.append(" " + Tbj37RdProgram.NLDIV + ",");
        sql.append(" " + Tbj37RdProgram.SECOND + ",");
        sql.append(" NVL(" + CNT + ", 0) " + Tbj37RdProgram.TIMES + ",");
        sql.append(" " + Tbj37RdProgram.TOTALSECOND + ",");
        sql.append(" " + Tbj37RdProgram.DATEFROM + ",");
        sql.append(" " + Tbj37RdProgram.DATETO + ",");
        sql.append(" " + Tbj37RdProgram.KEYSTATIONCD + ",");
        sql.append(" " + Tbj37RdProgram.STARTTIME + ",");
        sql.append(" " + Tbj37RdProgram.ENDTIME + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.SALESPRICE + ",");
        sql.append(" " + Tbj37RdProgram.CONFIGPRICEDIV + ",");
        sql.append(" " + Tbj37RdProgram.CONFIGPRICE + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRMON + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRTUE + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRWED + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRTHU + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRFRI + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRSAT + ",");
        sql.append(" " + Tbj37RdProgram.ONAIRSUN + ",");
        sql.append(" " + Tbj37RdProgram.CRTDATE + ",");
        sql.append(" " + Tbj37RdProgram.CRTNM + ",");
        sql.append(" " + Tbj37RdProgram.CRTAPL + ",");
        sql.append(" " + Tbj37RdProgram.CRTID + ",");
        sql.append(" " + Tbj37RdProgram.UPDDATE + ",");
        sql.append(" " + Tbj37RdProgram.UPDNM + ",");
        sql.append(" " + Tbj37RdProgram.UPDAPL + ",");
        sql.append(" " + Tbj37RdProgram.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj37RdProgram.TBNAME + ",");
        sql.append(" " + VW_RDPGMWAKU);

        sql.append(" WHERE");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + " = " + Tbj38RdProgramMaterial.RDSEQNO + "(+)");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj37RdProgram.RDSEQNO);

        return sql.toString();
    }

    /**
     * ラジオ番組登録画面素材情報検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj37RdProgramVO> findRdProgramInfo(Tbj37RdProgramCondition cond) throws HAMException {

        super.setModel(new Tbj37RdProgramVO());

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
