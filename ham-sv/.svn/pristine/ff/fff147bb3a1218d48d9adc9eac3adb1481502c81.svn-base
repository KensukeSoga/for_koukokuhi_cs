package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj51Natural;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* ラジオ版AllocationPicture番組素材情報検索DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/11/20 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
public class FindRdAllocationPictureProgramMaterialDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private FindRdAllocationPictureProgramMaterialCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindRdAllocationPictureProgramMaterialDAO() {
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

        return getRdProgramMaterialInfo();
    }

    /**
     * ラジオ番組素材情報検索SQL文を返します
     * @return String SQL文
     */
    private String getRdProgramMaterialInfo() {

        StringBuilder sql = new StringBuilder();

        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Mbj51Natural.NO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD);

        sql.append(" FROM");
        sql.append(" (");

        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ + ",");
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
        sql.append(" END " + Tbj18SozaiKanriData.CMCD);

        sql.append(" FROM");
        sql.append(" " + Tbj38RdProgramMaterial.TBNAME);
        sql.append(" CROSS JOIN");
        sql.append(" " + Mbj51Natural.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + " IN ( " + _cond.getRdSeqNo() + " ) AND");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + " = '" + _cond.getYearMonth() + "'");
        sql.append(" )");

        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " IS NOT NULL");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Mbj51Natural.NO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ);

        return sql.toString();
    }

    /**
     * ラジオ版AllocationPicture素材情報検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindRdAllocationPictureProgramMaterialVO> findRdProgramMaterialInfo(FindRdAllocationPictureProgramMaterialCondition cond) throws HAMException {

        super.setModel(new FindRdAllocationPictureProgramMaterialVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
