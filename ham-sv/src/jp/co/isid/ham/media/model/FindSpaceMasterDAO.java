package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu29Cc;
import jp.co.isid.ham.integ.tbl.Tbj35Knr;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* マスタからスペースを検索
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/09/12 T.Fujiyoshi)<BR>
* </P>
* @author T.Fujiyoshi
*/
public class FindSpaceMasterDAO extends AbstractSimpleRdbDao {

    /**
     * コンストラクタ
     */
    public FindSpaceMasterDAO() {
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
        return null;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu29Cc.KYCDKND
                ,RepaVbjaMeu29Cc.KYCD
                ,RepaVbjaMeu29Cc.HKYMD
                ,RepaVbjaMeu29Cc.HAISYMD
                ,RepaVbjaMeu29Cc.NAIYKN
                ,RepaVbjaMeu29Cc.NAIYJ
                ,RepaVbjaMeu29Cc.YOBI1
                ,RepaVbjaMeu29Cc.HOSOK
                ,RepaVbjaMeu29Cc.YOBI2
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        StringBuffer tbl = new StringBuffer();

        tbl.append(RepaVbjaMeu29Cc.TBNAME);
        tbl.append(", ");
        tbl.append(Tbj35Knr.TBNAME);

        return tbl.toString();
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    @Override
    public String getSelectSQL() {

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
        sql.append(getTableName());
        sql.append(" WHERE ");
        sql.append(Tbj35Knr.SYSTEMNO + " = '02'");
        sql.append(" AND ");
        sql.append(RepaVbjaMeu29Cc.HKYMD + " <= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND ");
        sql.append(RepaVbjaMeu29Cc.HAISYMD + " >= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND ");
        sql.append(RepaVbjaMeu29Cc.KYCDKND + " = 'WE'");
        sql.append(" AND ");
        sql.append(RepaVbjaMeu29Cc.NAIYKN + " != '1KEN'");
        sql.append(" ORDER BY ");
        sql.append(RepaVbjaMeu29Cc.KYCD);

        return sql.toString();
    }

    /**
     *検索を行い、データを取得します
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu29CcVO> selectVO() throws HAMException {

        super.setModel(new RepaVbjaMeu29CcVO());

        try {
            return (List<RepaVbjaMeu29CcVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
