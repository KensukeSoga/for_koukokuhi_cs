package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj03MediaMngCondition;
import jp.co.isid.ham.common.model.Tbj03MediaMngVO;
import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * 媒体費管理取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMediaMngDAO extends AbstractRdbDao {

    /** 検索条件 */
    private Tbj03MediaMngCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindMediaMngDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj03MediaMng.MEDIAMNGNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj03MediaMng.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj03MediaMng.CRTDATE
                ,Tbj03MediaMng.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj03MediaMng.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj03MediaMng.MEDIAMNGNO
                ,Tbj03MediaMng.PHASE
                ,Tbj03MediaMng.MDYEAR
                ,Tbj03MediaMng.MDMONTH
                ,Tbj03MediaMng.DCARCD
                ,Tbj03MediaMng.MEDIACD
                ,Tbj03MediaMng.HMCOSTTOTAL
                ,Tbj03MediaMng.CRTDATE
                ,Tbj03MediaMng.CRTNM
                ,Tbj03MediaMng.CRTAPL
                ,Tbj03MediaMng.CRTID
                ,Tbj03MediaMng.UPDDATE
                ,Tbj03MediaMng.UPDNM
                ,Tbj03MediaMng.UPDAPL
                ,Tbj03MediaMng.UPDID
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
        sql.append(Tbj03MediaMng.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj03MediaMng.MDYEAR);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getMdyear());
        sql.append("'");
        sql.append(" AND ");
        sql.append(Tbj03MediaMng.MDMONTH);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getMdmonth());
        sql.append("'");

        if (_condition.getDcarcd() != null && _condition.getDcarcd().length() > 0) {
            sql.append(" AND ");
            sql.append(Tbj03MediaMng.DCARCD);
            sql.append(" = ");
            sql.append("'");
            sql.append(_condition.getDcarcd());
            sql.append("'");
        }

        if (_condition.getMediacd() != null && _condition.getMediacd().length() > 0) {
            sql.append(" AND ");
            sql.append(Tbj03MediaMng.MEDIACD);
            sql.append(" = ");
            sql.append("'");
            sql.append(_condition.getMediacd());
            sql.append("'");
        }

        sql.append(" ORDER BY ");
        sql.append(Tbj03MediaMng.DCARCD);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj03MediaMngVO> selectVO(Tbj03MediaMngCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj03MediaMngVO());
        try
        {
            _condition = condition;
            return (List<Tbj03MediaMngVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
