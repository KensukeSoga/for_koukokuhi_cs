package jp.co.isid.ham.billing.model;

import java.util.List;
import jp.co.isid.ham.common.model.Tbj04MediaMngEstimateDetailCondition;
import jp.co.isid.ham.common.model.Tbj04MediaMngEstimateDetailVO;
import jp.co.isid.ham.integ.tbl.Tbj04MediaMngEstimateDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * 媒体費見積明細管理取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMediaMngEstDtlDAO extends AbstractRdbDao {

    /** 検索条件 */
    private Tbj04MediaMngEstimateDetailCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindMediaMngEstDtlDAO() {
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
        return new String[] {
                Tbj04MediaMngEstimateDetail.MEDIAMNGNO
                ,Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return Tbj04MediaMngEstimateDetail.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj04MediaMngEstimateDetail.CRTDATE
                ,Tbj04MediaMngEstimateDetail.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return Tbj04MediaMngEstimateDetail.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj04MediaMngEstimateDetail.MEDIAMNGNO
                ,Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO
                ,Tbj04MediaMngEstimateDetail.PHASE
                ,Tbj04MediaMngEstimateDetail.MDYEAR
                ,Tbj04MediaMngEstimateDetail.MDMONTH
                ,Tbj04MediaMngEstimateDetail.CRTDATE
                ,Tbj04MediaMngEstimateDetail.CRTNM
                ,Tbj04MediaMngEstimateDetail.CRTAPL
                ,Tbj04MediaMngEstimateDetail.CRTID
                ,Tbj04MediaMngEstimateDetail.UPDDATE
                ,Tbj04MediaMngEstimateDetail.UPDNM
                ,Tbj04MediaMngEstimateDetail.UPDAPL
                ,Tbj04MediaMngEstimateDetail.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(", ");
            }
        }
        sql.append(" FROM ");
        sql.append(getTableName());

        sql.append(" WHERE ");
        sql.append(Tbj04MediaMngEstimateDetail.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj04MediaMngEstimateDetail.MDYEAR);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getMdyear());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj04MediaMngEstimateDetail.MDMONTH);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getMdmonth());
        sql.append("'");

        sql.append(" ORDER BY ");
        sql.append(Tbj04MediaMngEstimateDetail.MEDIAMNGNO);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj04MediaMngEstimateDetailVO> selectVO(Tbj04MediaMngEstimateDetailCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj04MediaMngEstimateDetailVO());
        try
        {
            _condition = condition;
            return (List<Tbj04MediaMngEstimateDetailVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
