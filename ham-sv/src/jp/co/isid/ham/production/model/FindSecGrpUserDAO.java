package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.T_SecurityGroup;
import jp.co.isid.ham.integ.tbl.T_TransactionSecurity;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;


/**
* <P>
* セキュリティグループユーザー検索DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・HDX対応(2016/03/23 HLC K.Oki)<BR>
* </P>
* @author K.Oki
*/
public class FindSecGrpUserDAO extends AbstractSimpleRdbDao {

    /**
     * デフォルトコンストラクタ
     */
    public FindSecGrpUserDAO() {
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
        return getSelectSQLFindSecGrpUser();
    }

    /**
     * HC/HM担当者検索SQLを作成する
     * @return String HC/HM担当者検索SQL文
     */
    private String getSelectSQLFindSecGrpUser() {

        StringBuilder sql = new StringBuilder();

        sql.append("SELECT");
        sql.append(" " + Mbj12Code.CODENAME + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" TRANSEC." + T_TransactionSecurity.TRANSACTIONNO + ",");
        sql.append(" USERINFO." + T_UserInfo.USERNAME + ",");
        sql.append(" SECGRP." + T_SecurityGroup.SECURITYGROUPCODE);

        sql.append(" FROM");
        sql.append(" " + T_TransactionSecurity.TBNAME + " TRANSEC,");
        sql.append(" " + T_UserInfo.TBNAME + " USERINFO,");
        sql.append(" " + T_SecurityGroup.TBNAME + " SECGRP,");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);

        sql.append(" WHERE");
        sql.append(" TRANSEC." + T_TransactionSecurity.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND");
        sql.append(" TRANSEC." + T_TransactionSecurity.SYSTEMID + " = '" + HAMConstants.SYSTEMID_HDX + "' AND");
        sql.append(" TRANSEC." + T_TransactionSecurity.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND");
        sql.append(" TRANSEC." + T_TransactionSecurity.MENUTABCODE + " = '" + HAMConstants.MENUTABCODE_HDX + "' AND");
        sql.append(" TRANSEC." + T_TransactionSecurity.USERID + " = USERINFO." + T_UserInfo.USERID + " AND");
        sql.append(" USERINFO." + T_UserInfo.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND");
        sql.append(" USERINFO." + T_UserInfo.SYSTEMID + " = '" + HAMConstants.SYSTEMID_HDX + "' AND");
        sql.append(" USERINFO." + T_UserInfo.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND");
        sql.append(" USERINFO." + T_UserInfo.SECURITYGROUPCODE + " = SECGRP." + T_SecurityGroup.SECURITYGROUPCODE + " AND");
        sql.append(" SECGRP." + T_SecurityGroup.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND");
        sql.append(" SECGRP." + T_SecurityGroup.SYSTEMID + " = '" + HAMConstants.SYSTEMID_HDX + "' AND");
        sql.append(" SECGRP." + T_SecurityGroup.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND");
        sql.append(" SECGRP." + T_SecurityGroup.SECURITYGROUPCODE + " = " + Mbj12Code.YOBI1 + "(+) AND");
        sql.append(" TRANSEC." + T_TransactionSecurity.TRANSACTIONNO + " = " + Mbj05Car.DCARCD + "(+)");

        return sql.toString();
    };

    /**
     * HC/HM担当者検索
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<HCHMSecGrpUserVO> findHCHMSecGrpUser( FindSecGrpUserCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new HCHMSecGrpUserVO());

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
