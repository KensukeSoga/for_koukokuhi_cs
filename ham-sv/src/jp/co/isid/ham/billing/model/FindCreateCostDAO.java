package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.tbl.Tbj21Seisakuhi;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
*
* <P>
* 制作費の情報取得DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/4/2 HLC H.Watabe)<BR>
* </P>
*
* @author HLC H.watabe
*/
public class FindCreateCostDAO extends AbstractSimpleRdbDao {

    /** データ検索条件 */
    private FindCostManagementReportCondition _cond;

    /**
     * デフォルトコンストラクタ
     */
    public FindCreateCostDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を取得
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                "SUM(" + Tbj21Seisakuhi.SEISAKUHIS + ") AS SUMSEISAKUHIS"
                ,Tbj21Seisakuhi.DCARCD
                ,Mbj05Car.CARNM
                ,"TRUNC(" + Tbj21Seisakuhi.SEIKYUYM + ", 'MM') AS TBJ21_SEIKYUYM"};
    }

    /**
     * テーブル名取得
     */
    @Override
    public String getTableName() {
        return Tbj21Seisakuhi.TBNAME;
    }

    /**
     * 更新日付フィールド取得
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

        return getCreateCost();
    }

    /**
     * 制作費データ取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getCreateCost()
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
        sql.append(" " + getTableName() + ", ");
        sql.append(" " + Mbj05Car.TBNAME + ", ");
        sql.append(" " + Mbj13CarOutCtrl.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj21Seisakuhi.SEIKYUYM + " >= TO_DATE('" + _cond.getKikanFrom() + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" " + Tbj21Seisakuhi.SEIKYUYM + " < TO_DATE('" + _cond.getKikanTo() + "','YYYY/MM') ");
        sql.append(" AND ");
        sql.append(" " + Tbj21Seisakuhi.DCARCD + " = " + Mbj05Car.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj21Seisakuhi.DCARCD + " = " + Mbj13CarOutCtrl.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.REPORTCD + " = 'R05' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" AND ");
        sql.append(" " + Tbj21Seisakuhi.SEISAKUHIS + " <> 0 ");
        sql.append(" GROUP BY ");
        sql.append(" " + Tbj21Seisakuhi.DCARCD + ", ");
        sql.append(" " + Mbj05Car.CARNM + ", ");
        sql.append(" TRUNC(" + Tbj21Seisakuhi.SEIKYUYM + ",'MM'), ");
        sql.append(" " + Mbj13CarOutCtrl.SORTNO + " ");
        sql.append(" ORDER BY ");
        sql.append(" TO_CHAR(" + Tbj21Seisakuhi.SEIKYUYM + ",'YYYY/MM'), ");
        sql.append(" " + Mbj13CarOutCtrl.SORTNO + " ");


        return sql.toString();
    }


    /**
     * 制作費取得
     * @return 制作費VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindCreateCostVO> findCreateCost(
            FindCostManagementReportCondition cond) throws HAMException {

        super.setModel(new FindCreateCostVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
