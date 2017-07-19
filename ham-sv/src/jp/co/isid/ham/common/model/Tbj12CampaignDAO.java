package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * キャンペーン一覧DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj12CampaignDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj12CampaignCondition _condition = null;
    private String _campCd = null;

    /**SQLモードの選択*/
    private enum SqlMode{ALL,MAX,CD,GETCAMPCD};
    private SqlMode _sqlMode = SqlMode.MAX;


    /**
     * デフォルトコンストラクタ
     */
    public Tbj12CampaignDAO() {
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
                Tbj12Campaign.CAMPCD
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj12Campaign.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj12Campaign.CRTDATE
                ,Tbj12Campaign.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj12Campaign.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj12Campaign.CAMPCD
                ,Tbj12Campaign.DCARCD
                ,Tbj12Campaign.PHASE
                ,Tbj12Campaign.KIKANFROM
                ,Tbj12Campaign.KIKANTO
                ,Tbj12Campaign.CAMPNM
                ,Tbj12Campaign.FSTBUDGET
                ,Tbj12Campaign.BUDGET
                ,Tbj12Campaign.BUDGETHM
                ,Tbj12Campaign.ACTUAL
                ,Tbj12Campaign.ACTUALHM
                ,Tbj12Campaign.MEMO
                ,Tbj12Campaign.BAITAIFLG
                ,Tbj12Campaign.CRTDATE
                ,Tbj12Campaign.CRTNM
                ,Tbj12Campaign.CRTAPL
                ,Tbj12Campaign.CRTID
                ,Tbj12Campaign.UPDDATE
                ,Tbj12Campaign.UPDNM
                ,Tbj12Campaign.UPDAPL
                ,Tbj12Campaign.UPDID
        };
    }


    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        String sql = "";
        if (_sqlMode.equals(SqlMode.ALL)) {
            sql = getAllCampaign();
        } else if (_sqlMode.equals(SqlMode.MAX)) {
            sql = getMaxCampaignNoSQLByCondition();
        } else if (_sqlMode.equals(SqlMode.CD)) {
            sql = getCampaignListByCampCd();
        } else if (_sqlMode.equals(SqlMode.GETCAMPCD)) {
            sql = getCampaignCd();
        }
        return sql;
    }

    /**
     * キャンペーンデータ全取得
     * @return SQL文
     */
    private String getAllCampaign() {

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
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj12Campaign.CAMPCD + " ASC ");

        return sql.toString();
    }

    /**キャンペーンMAX値取得*/
    private String getMaxCampaignNoSQLByCondition() {

         StringBuffer sql = new StringBuffer();

         sql.append("SELECT ");
         sql.append(" NVL(MAX(" + Tbj12Campaign.CAMPCD + "),'CP0000') AS " + Tbj12Campaign.CAMPCD);
         sql.append(" FROM ");
         sql.append(" " + getTableName() + " ");


         return sql.toString();
    }


    /**
     * キャンペーンコードの行を取得
     * @return SQL文
     */
    private String getCampaignListByCampCd() {
         StringBuffer sql = new StringBuffer();

         sql.append("SELECT ");
         sql.append(" * ");
         sql.append(" FROM ");
         sql.append(" " + getTableName() + " ");
         sql.append(" WHERE ");
         sql.append(" " + Tbj12Campaign.CAMPCD + " = '" + _campCd + "' ");


         return sql.toString();
    }

    private String getCampaignCd() {
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
        sql.append(" " + Tbj12Campaign.DCARCD + " = '" + _condition.getDcarcd() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj12Campaign.PHASE + " = '" + _condition.getPhase() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj12Campaign.KIKANFROM + " <= " + getDBModelInterface().ConvertToDBString(_condition.getKikanfrom()) + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj12Campaign.KIKANTO + " >= " + getDBModelInterface().ConvertToDBString(_condition.getKikanto()) + " ");

        return sql.toString();
    }

    /**
     * キャンペーン全取得
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj12CampaignVO> findAllCampaign() throws HAMException {

        super.setModel(new Tbj12CampaignVO());

        try {
            _sqlMode = SqlMode.ALL;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * キャンペーンコード最大値取得
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj12CampaignVO> findMaxCampCd() throws HAMException {

        super.setModel(new Tbj12CampaignVO());

        try {
            _sqlMode = SqlMode.MAX;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * キャンペーンコードのキャンペーンを取得する.
     * @param キャンペーンコード
     * @return キャンペーン一覧
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj12CampaignVO> findCampaignListByCampCd(String campaignCd) throws HAMException {

        super.setModel(new Tbj12CampaignVO());

        try {
            _sqlMode = SqlMode.CD;
            _campCd = campaignCd;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 営業作業台帳の入力データでキャンペーンを取得
     * @param cond 検索条件
     * @return キャンペーン一覧
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj12CampaignVO> findCampaignCd(Tbj12CampaignCondition cond) throws HAMException {

        super.setModel(new Tbj12CampaignVO());

        try {
            _sqlMode = SqlMode.GETCAMPCD;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
