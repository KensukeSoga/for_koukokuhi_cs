package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj13CampDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.media.model.FindCampaignDetailsCondition;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * キャンペーン明細DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj13CampDetailDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj13CampDetailCondition _condition = null;
    private FindCampaignDetailsCondition _findCondition = null;
    private String _CampaignCd = null;
    /**SQL選択*/
    private enum SqlMode{SH,BU,KI,BYKEY};
    private SqlMode _sqlMode = SqlMode.SH;
    /**
     * デフォルトコンストラクタ
     */
    public Tbj13CampDetailDAO() {
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
                Tbj13CampDetail.CAMPCD
                ,Tbj13CampDetail.MEDIACD
                ,Tbj13CampDetail.PHASE
                ,Tbj13CampDetail.YOTEIYM
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj13CampDetail.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj13CampDetail.CRTDATE
                ,Tbj13CampDetail.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj13CampDetail.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj13CampDetail.CAMPCD
                ,Tbj13CampDetail.DCARCD
                ,Tbj13CampDetail.MEDIACD
                ,Tbj13CampDetail.PHASE
                ,Tbj13CampDetail.YOTEIYM
                ,Tbj13CampDetail.KIKANFROM
                ,Tbj13CampDetail.KIKANTO
                ,Tbj13CampDetail.BUDGET
                ,Tbj13CampDetail.BUDGETHM
                ,Tbj13CampDetail.CRTDATE
                ,Tbj13CampDetail.CRTNM
                ,Tbj13CampDetail.CRTAPL
                ,Tbj13CampDetail.CRTID
                ,Tbj13CampDetail.UPDDATE
                ,Tbj13CampDetail.UPDNM
                ,Tbj13CampDetail.UPDAPL
                ,Tbj13CampDetail.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.SH)) {
            sql = findCampaignDetails();
        } else if (_sqlMode.equals(SqlMode.BU)) {
            sql = findCampaignDetailsBudget();
        } else if (_sqlMode.equals(SqlMode.KI)) {
            sql = findCampaignDetailsKikan();
        } else if (_sqlMode.equals(SqlMode.BYKEY)) {
            sql = findCampaignDetailsByKey();
        }

        return sql;
    }

    /**
     *キャンペーン詳細を取得します.
     *@return SQL文.
     */
    private String findCampaignDetails() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" * ");
        sql.append(" FROM ");
        sql.append(" "+ getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + " = '" + _findCondition.getCampaignNo() + "' ");

        return sql.toString();
    }

    /**
     *キャンペーン詳細の合計予算を取得します.
     *@return SQL文.
     *
     */
    private String findCampaignDetailsBudget() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + ", ");
        sql.append(" SUM(" + Tbj13CampDetail.BUDGET+ ") AS " + Tbj13CampDetail.BUDGET + ", ");
        sql.append(" SUM(" + Tbj13CampDetail.BUDGETHM+ ") AS " + Tbj13CampDetail.BUDGETHM + " ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + " = '" + _CampaignCd + "' ");
        sql.append(" GROUP BY ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + " ");

        return sql.toString();
    }

    /**
     *キャンペーン詳細の期間の最小最大を取得します
     *@return SQL文.
     */
    private String findCampaignDetailsKikan() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" MIN(" + Tbj13CampDetail.KIKANFROM + ") AS " + Tbj13CampDetail.KIKANFROM + ", ");
        sql.append(" MAX(" + Tbj13CampDetail.KIKANTO + ") AS " + Tbj13CampDetail.KIKANTO + " ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + " = '" + _CampaignCd + "' ");

        return sql.toString();
    }

    /**
     *キャンペーン詳細を取得します.
     *@return SQL文.
     */
    private String findCampaignDetailsByKey() {

        StringBuffer sql = new StringBuffer();
        sql.append(" SELECT ");
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
        sql.append(" " +Tbj13CampDetail.CAMPCD +" ='" + _condition.getCampcd() + "' ");
        sql.append(" AND ");
        sql.append(" " +Tbj13CampDetail.DCARCD +" ='" + _condition.getDcarcd() + "' ");
        sql.append(" AND ");
        sql.append(" " +Tbj13CampDetail.MEDIACD +" ='" + _condition.getMediacd() + "' ");
        sql.append(" AND ");
        sql.append(" " +Tbj13CampDetail.PHASE +" = " + _condition.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " +Tbj13CampDetail.YOTEIYM +" = " + getDBModelInterface().ConvertToDBString(_condition.getYoteiym()) + " ");

        return sql.toString();
    }

    /**
     * キャンペーン詳細の検索を行います
     *
     * @return キャンペーン一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj13CampDetailVO> findCampaignDetailsByCond(
            FindCampaignDetailsCondition cond) throws HAMException {
        super.setModel(new Tbj13CampDetailVO());
        try {
            _sqlMode = SqlMode.SH;
            _findCondition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * キャンペーン詳細の予算合計の検索行います
     *
     * @return キャンペーン一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj13CampDetailVO> findCampaignDetailsSumBudget(
            String CampaignCd) throws HAMException {
        super.setModel(new Tbj13CampDetailVO());
        try {
            _sqlMode = SqlMode.BU;
            _CampaignCd = CampaignCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * キャンペーン詳細の期間の検索を行います
     *
     * @return キャンペーン一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj13CampDetailVO> findCampaignDetailsKikan(
            String CampaignCd) throws HAMException {
        super.setModel(new Tbj13CampDetailVO());
        try {
            _sqlMode = SqlMode.KI;
            _CampaignCd = CampaignCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * 複合キーで検索を行う
     * @param CampaignCd
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj13CampDetailVO> findCampaignDetailsByKey(Tbj13CampDetailCondition cond) throws HAMException {
        super.setModel(new Tbj13CampDetailVO());
        try {
            _sqlMode = SqlMode.BYKEY;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

}
