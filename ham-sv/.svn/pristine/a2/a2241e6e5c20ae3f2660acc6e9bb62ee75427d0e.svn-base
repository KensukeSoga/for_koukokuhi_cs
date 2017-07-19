package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj37RdProgramVO;
import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* ラジオ版AllocationPicture番組情報検索DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/11/20 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
public class FindRdAllocationPictureProgramDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private FindRdAllocationPictureProgramCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindRdAllocationPictureProgramDAO() {
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

        return getRdProgramInfo();
    }

    /**
     * ラジオ番組情報検索SQL文を返します
     * @return String SQL文
     */
    private String getRdProgramInfo() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + ",");
        sql.append(" " + Tbj37RdProgram.PHASE + ",");
        sql.append(" " + Tbj37RdProgram.PROGRAMNM + ",");
        sql.append(" " + Tbj37RdProgram.RSDIV + ",");
        sql.append(" " + Tbj37RdProgram.NLDIV + ",");
        sql.append(" " + Tbj37RdProgram.SECOND + ",");
        sql.append(" " + Tbj37RdProgram.TIMES + ",");
        sql.append(" " + Tbj37RdProgram.TOTALSECOND+ ",");
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
        sql.append(" " + Tbj37RdProgram.ONAIRSUN);

        sql.append(" FROM");
        sql.append(" " + Tbj37RdProgram.TBNAME);

        sql.append(" WHERE");
        sql.append(" TO_CHAR(" + Tbj37RdProgram.DATEFROM + ", 'YYYYMM') <= '" + _cond.getYearMonth() + "' AND");
        sql.append(" TO_CHAR(" + Tbj37RdProgram.DATETO + ", 'YYYYMM') >= '" + _cond.getYearMonth() + "' AND");
        sql.append(" " + Tbj37RdProgram.RDSEQNO + " IN ( " + _cond.getRdSeqNo() + " )");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj37RdProgram.RDSEQNO);

        return sql.toString();
    }

    /**
     * ラジオ版AllocationPicture番組情報検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj37RdProgramVO> findRdProgramInfo(FindRdAllocationPictureProgramCondition cond) throws HAMException {

        super.setModel(new Tbj37RdProgramVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
