package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj39RdProgramStationVO;
import jp.co.isid.ham.integ.tbl.Tbj39RdProgramStation;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* ラジオ版AllocationPicture番組ネット局情報検索DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/11/20 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
public class FindRdAllocationPictureProgramStationDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private FindRdAllocationPictureProgramStationCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindRdAllocationPictureProgramStationDAO() {
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

        return getMaterialInfo();
    }

    /**
     * ラジオ版AllocationPicture番組ネット局情報検索SQL文を返します
     * @return String SQL文
     */
    private String getMaterialInfo() {

        StringBuilder sql = new StringBuilder();

        sql.append(" SELECT");
        sql.append(" " + Tbj39RdProgramStation.RDSEQNO + ",");
        sql.append(" " + Tbj39RdProgramStation.STATIONCD);

        sql.append(" FROM");
        sql.append(" " + Tbj39RdProgramStation.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj39RdProgramStation.RDSEQNO + " IN ( " + _cond.getRdSeqNo() + " )");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj39RdProgramStation.RDSEQNO + ",");
        sql.append(" " + Tbj39RdProgramStation.STATIONCD);

        return sql.toString();
    }

    /**
     * ラジオ版AllocationPicture番組ネット局情報検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj39RdProgramStationVO> findProgramStationInfo(FindRdAllocationPictureProgramStationCondition cond) throws HAMException {

        super.setModel(new Tbj39RdProgramStationVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
