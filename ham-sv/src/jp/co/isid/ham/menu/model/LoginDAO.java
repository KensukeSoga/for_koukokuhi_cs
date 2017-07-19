package jp.co.isid.ham.menu.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj02User;
import jp.co.isid.ham.integ.tbl.Tbj29LoginUser;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * ログインDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class LoginDAO extends AbstractRdbDao {

    /**
     * デフォルトコンストラクタ
     */
    public LoginDAO() {
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
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj29LoginUser.UPDDATE,
                Tbj29LoginUser.AFFILIATION,
                Tbj29LoginUser.HAMID,
                Mbj02User.USERNAME1 + " || " + Mbj02User.USERNAME2  + " AS FULLNAME"
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
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
        sql.append(Tbj29LoginUser.TBNAME);
        sql.append(", ");
        sql.append(Mbj02User.TBNAME);
        sql.append(" WHERE ");
        sql.append(Tbj29LoginUser.HAMID);
        sql.append(" = ");
        sql.append(Mbj02User.HAMID);
        sql.append("(+)");
        sql.append(" ORDER BY ");
        sql.append(Tbj29LoginUser.UPDDATE);

        return sql.toString();
    }

    /**
     * 全データを取得します
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<LoginVO> selectVO() throws HAMException {

        super.setModel(new LoginVO());

        try {
            return (List<LoginVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
