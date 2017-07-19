package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj14FeeKanri;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * フィー管理DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj14FeeKanriDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj14FeeKanriCondition _condition = null;
    private String _kikanFrom = null;
    private String _kikanTo = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj14FeeKanriDAO() {
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
                Tbj14FeeKanri.PHASE
                ,Tbj14FeeKanri.SEIKYUYM
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj14FeeKanri.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj14FeeKanri.CRTDATE
                ,Tbj14FeeKanri.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj14FeeKanri.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj14FeeKanri.PHASE
                ,Tbj14FeeKanri.SEIKYUYM
                ,Tbj14FeeKanri.JINKENHI
                ,Tbj14FeeKanri.HANSOKUHI
                ,Tbj14FeeKanri.SYUTTYOUHI
                ,Tbj14FeeKanri.JIPPI
                ,Tbj14FeeKanri.MONTHADJUST
                ,Tbj14FeeKanri.CRTDATE
                ,Tbj14FeeKanri.CRTNM
                ,Tbj14FeeKanri.CRTID
                ,Tbj14FeeKanri.UPDDATE
                ,Tbj14FeeKanri.UPDNM
                ,Tbj14FeeKanri.UPDAPL
                ,Tbj14FeeKanri.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return getPhaseFee();
    }

    /**
     * フェイズ単位のフィー管理取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getPhaseFee()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj14FeeKanri.SEIKYUYM + " >= TO_DATE('" + _kikanFrom + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" " + Tbj14FeeKanri.SEIKYUYM + " <= TO_DATE('" + _kikanTo + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" " + Tbj14FeeKanri.PHASE + " = " + _condition.getPhase() + " ");

        return sql.toString();
    }


    /**
     * 媒体コスト取得
     * @return 媒体コストVOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj14FeeKanriVO> findPhaseFee(
            Tbj14FeeKanriCondition cond,String kikanFrom,String kikanTo) throws HAMException {

        super.setModel(new Tbj14FeeKanriVO());

        try {
            _condition = cond;
            _kikanFrom = kikanFrom;
            _kikanTo = kikanTo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }


}
