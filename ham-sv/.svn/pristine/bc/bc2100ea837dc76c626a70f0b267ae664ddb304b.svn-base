package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj34CutManagement;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 削減額管理DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj34CutManagementDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj34CutManagementCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj34CutManagementDAO() {
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
                Tbj34CutManagement.CLASSCD
                ,Tbj34CutManagement.DATEFROM
                ,Tbj34CutManagement.DATETO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj34CutManagement.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj34CutManagement.CRTDATE
                ,Tbj34CutManagement.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj34CutManagement.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj34CutManagement.CLASSCD
                ,Tbj34CutManagement.DATEFROM
                ,Tbj34CutManagement.DATETO
                ,Tbj34CutManagement.CUTMONEY
                ,Tbj34CutManagement.CRTDATE
                ,Tbj34CutManagement.CRTNM
                ,Tbj34CutManagement.CRTAPL
                ,Tbj34CutManagement.CRTID
                ,Tbj34CutManagement.UPDDATE
                ,Tbj34CutManagement.UPDNM
                ,Tbj34CutManagement.UPDAPL
                ,Tbj34CutManagement.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        return getKikan();
    }

    /**
     * 検索SQLを取得します
     * @return
     */
    private String getKikan() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        for (int i = 0;i < getTableColumnNames().length;i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(",");
            }
        }

        sql.append(" FROM ");
        sql.append(" " + getTableName());
        sql.append(" WHERE ");
        sql.append(" TO_DATE(" + Tbj34CutManagement.DATEFROM + ") >= TO_DATE('" + _condition.getDatefrom() + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" TO_DATE(" + Tbj34CutManagement.DATETO + ") <= TO_DATE('" + _condition.getDateto() + "','YYYY/MM') ");

        return sql.toString();
    }


    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj34CutManagementVO> selectVO(Tbj34CutManagementCondition condition) throws HAMException
    {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj34CutManagementVO());
        _condition = condition;
        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
