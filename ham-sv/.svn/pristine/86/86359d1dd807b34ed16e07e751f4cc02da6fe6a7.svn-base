package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu14ThsTntTr;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 取引先担当（取）DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu14ThsTntTrDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private RepaVbjaMeu14ThsTntTrCondition _condition = null;

    /** 期間開始 */
    private String _kikanFrom;

    /** 期間終了 */
    private String _kikanTo;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu14ThsTntTrDAO() {
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
        return null;
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return null;
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return RepaVbjaMeu14ThsTntTr.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu14ThsTntTr.THSKGYCD
                ,RepaVbjaMeu14ThsTntTr.SEQNO
                ,RepaVbjaMeu14ThsTntTr.TRTNTSEQNO
                ,RepaVbjaMeu14ThsTntTr.ENDYMD
                ,RepaVbjaMeu14ThsTntTr.STARTYMD
                ,RepaVbjaMeu14ThsTntTr.SNSTNT
                ,RepaVbjaMeu14ThsTntTr.SIKCD
                ,RepaVbjaMeu14ThsTntTr.CLNTKBN
                ,RepaVbjaMeu14ThsTntTr.TKKBN
                ,RepaVbjaMeu14ThsTntTr.SKYUSKBN
                ,RepaVbjaMeu14ThsTntTr.NKINSKBN
                ,RepaVbjaMeu14ThsTntTr.MKMTKSKBN
                ,RepaVbjaMeu14ThsTntTr.EGHISHRSKBN
                ,RepaVbjaMeu14ThsTntTr.SINSEINO
                ,RepaVbjaMeu14ThsTntTr.EGSYOCD
                ,RepaVbjaMeu14ThsTntTr.CLNTKGYCD
                ,RepaVbjaMeu14ThsTntTr.CLNTSEQNO
                ,RepaVbjaMeu14ThsTntTr.KYUTRCD
                ,RepaVbjaMeu14ThsTntTr.TRTNTYOBI
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        return getCharge();
    }


    /**
     * 取引先情報検索のSQL文を返します
     *
     * @return String SQL文
     */
    private String getCharge()
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
        sql.append(" " + RepaVbjaMeu14ThsTntTr.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.EGSYOCD + " ='" + _condition.getEgsyocd() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.THSKGYCD + " ='" + _condition.getThskgycd() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.SEQNO + " ='" + _condition.getSeqno() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.TRTNTSEQNO + " ='" + _condition.getTrtntseqno() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.STARTYMD + " <='" + _kikanFrom + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu14ThsTntTr.ENDYMD + " >='" + _kikanTo + "' ");


        return sql.toString();
    }

    /**
     * 取引先情報の検索を行います
     *
     * @return 取引先情報VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu14ThsTntTrVO> findCharge(
            RepaVbjaMeu14ThsTntTrCondition cond,String kikanFrom,String kikanTo) throws HAMException {

        super.setModel(new RepaVbjaMeu14ThsTntTrVO());

        try {
            _condition = cond;
            _kikanFrom = kikanFrom;
            _kikanTo = kikanTo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
