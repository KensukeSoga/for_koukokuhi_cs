package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj06EstimateDetailCondition;
import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.tbl.Tbj04MediaMngEstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
/**
 * <P>
 * 請求先Grコード更新チェック用DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/04/20 HDX対応 K.Soga)<BR>
 * </P>
 * @author K.Soga
 */
public class CheckUpdateHCBumonCdBillDAO extends AbstractRdbDao {

    private Tbj06EstimateDetailCondition _condition = null;

    /** デフォルトコンストラクタ */
    public CheckUpdateHCBumonCdBillDAO() {
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
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return null;
    }

    /**
     * 更新日付フィールドを取得する
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
        String sql = null;
        sql = getCheckUpdateHcBumonCdBill();
        return sql.toString();
    }

    /**
     * 請求先Grコード更新チェック用SQL作成
     * @return String SQL文
     */
    public String getCheckUpdateHcBumonCdBill() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + ",");
        sql.append(" " + Tbj06EstimateDetail.PHASE + ",");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + ",");
        sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + ",");
        sql.append(" " + Tbj03MediaMng.DCARCD + ",");
        sql.append(" " + Tbj03MediaMng.MEDIACD + ",");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO);

        sql.append(" FROM");
        sql.append(" " + Tbj03MediaMng.TBNAME + ",");
        sql.append(" " + Tbj04MediaMngEstimateDetail.TBNAME + ",");
        sql.append(" " + Tbj06EstimateDetail.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj06EstimateDetail.PHASE + " = " + _condition.getPhase() + " AND");
        sql.append(" " + Tbj06EstimateDetail.CRDATE + " = '" + DateUtil.toString(_condition.getCrdate()) + "' AND");
        sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + " LIKE '1%' AND");
        sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + " IS NULL AND");
        sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + " = " + Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO + " AND");
        sql.append(" " + Tbj04MediaMngEstimateDetail.MEDIAMNGNO + " = " + Tbj03MediaMng.MEDIAMNGNO);

        return sql.toString();
    }

    /**
     * 請求先Grコード更新チェック用
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<CheckUpdateHCBumonCdBillVO> checkUpdateHcBumonCdBill(Tbj06EstimateDetailCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new CheckUpdateHCBumonCdBillVO());

        try {
            _condition = condition;
            return (List<CheckUpdateHCBumonCdBillVO> ) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}