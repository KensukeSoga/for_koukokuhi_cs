package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.T_MaterialHistory;
import jp.co.isid.ham.integ.tbl.T_SecurityGroup;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* TVCM素材一覧最終更新者検索DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・HDX対応(2016/03/09 HLC K.Oki)<BR>
* </P>
* @author K.Oki
*/
public class FindTVCMMaterialListLastUpdateUserDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private FindTVCMMaterialListCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindTVCMMaterialListLastUpdateUserDAO() {
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

        return getLastUpdateUser();
    }

    /**
     * TVCM素材一覧最終更新者検索SQL文を返します
     * @return String SQL文
     */
    private String getLastUpdateUser() {
        StringBuilder sql = new StringBuilder();

        sql.append("SELECT");
        sql.append(" " + T_MaterialHistory.UPDATEDATE + ",");
        sql.append(" " + T_MaterialHistory.UPDATEUSERID + ",");
        sql.append(" " + T_MaterialHistory.DELETEFLG + ",");
        sql.append(" " + T_MaterialHistory.CURRENTFLG + ",");
        sql.append(" " + T_MaterialHistory.STATUS + ",");
        sql.append(" " + T_MaterialHistory.DCARCD + ",");
        sql.append(" " + T_MaterialHistory.SOZAIYM + ",");
        sql.append(" " + T_MaterialHistory.RECKBN + ",");
        sql.append(" " + T_MaterialHistory.RECNO + ",");
        sql.append(" " + T_UserInfo.USERNAME + ",");
        sql.append(" " + T_SecurityGroup.SECURITYGROUPNAME);

        sql.append(" FROM(");
        sql.append("SELECT");
        sql.append(" MH." + T_MaterialHistory.UPDATEDATE + ",");
        sql.append(" MH." + T_MaterialHistory.UPDATEUSERID + ",");
        sql.append(" MH." + T_MaterialHistory.DELETEFLG + ",");
        sql.append(" MH." + T_MaterialHistory.CURRENTFLG + ",");
        sql.append(" MH." + T_MaterialHistory.STATUS + ",");
        sql.append(" MH." + T_MaterialHistory.DCARCD + ",");
        sql.append(" MH." + T_MaterialHistory.SOZAIYM + ",");
        sql.append(" MH." + T_MaterialHistory.RECKBN + ",");
        sql.append(" MH." + T_MaterialHistory.RECNO + ",");
        sql.append(" UI." + T_UserInfo.USERNAME + ",");
        sql.append(" SG." + T_SecurityGroup.SECURITYGROUPNAME + ",");
        sql.append(" ROW_NUMBER() OVER(PARTITION BY");
        sql.append(" MH." + T_MaterialHistory.DCARCD + ", MH." + T_MaterialHistory.SOZAIYM + ", MH." + T_MaterialHistory.RECKBN + ", MH." + T_MaterialHistory.RECNO);
        sql.append(" ORDER BY MH." + T_MaterialHistory.UPDATEDATE + " DESC) RNO");

        sql.append(" FROM");
        sql.append(" " + T_MaterialHistory.TBNAME + " MH,");
        sql.append(" " + T_SecurityGroup.TBNAME + " SG,");
        sql.append(" " + T_UserInfo.TBNAME + " UI");

        sql.append(" WHERE");
        sql.append(" MH." + T_MaterialHistory.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND");
        sql.append(" MH." + T_MaterialHistory.STATUS + " = '" + HAMConstants.MATERIALHISTORY_ALREADY + "' AND");
        sql.append(" MH." + T_MaterialHistory.UPDATEUSERID + " = UI." + T_UserInfo.USERID + " AND");
        sql.append(" UI." + T_UserInfo.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND");
        sql.append(" UI." + T_UserInfo.USERTYPE01 + " = '" + HAMConstants.ONE + "' AND");
        sql.append(" UI." + T_UserInfo.SECURITYGROUPCODE + " = SG." + T_SecurityGroup.SECURITYGROUPCODE + " AND");
        sql.append(" SG." + T_SecurityGroup.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND");
        sql.append(" MH." + T_MaterialHistory.SOZAIYM + " = TO_DATE('" + _cond.getYearMonth() + "', 'YYYYMM')");
        sql.append(" )");

        sql.append(" WHERE");
        sql.append(" RNO = '" + HAMConstants.ONE + "'");

        sql.append(" ORDER BY");
        sql.append(" " + T_MaterialHistory.DCARCD + ",");
        sql.append(" " + T_MaterialHistory.SOZAIYM + ",");
        sql.append(" " + T_MaterialHistory.RECKBN + ",");
        sql.append(" " + T_MaterialHistory.RECNO);

        return sql.toString();
    }

    /**
     * TVCM素材一覧最終更新者検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindTVCMMaterialListLastUpdateUserVO> findTVCMMaterialListLastUpdateUser(FindTVCMMaterialListCondition cond) throws HAMException {

        super.setModel(new FindTVCMMaterialListLastUpdateUserVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
