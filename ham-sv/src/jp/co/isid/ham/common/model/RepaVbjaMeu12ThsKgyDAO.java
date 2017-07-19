package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 取引先企業DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu12ThsKgyDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    //private RepaVbjaMeu12ThsKgyCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu12ThsKgyDAO() {
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
                RepaVbjaMeu12ThsKgy.THSKGYCD
                ,RepaVbjaMeu12ThsKgy.ENDYMD
        };
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
        return RepaVbjaMeu12ThsKgy.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu12ThsKgy.THSKGYCD
                ,RepaVbjaMeu12ThsKgy.ENDYMD
                ,RepaVbjaMeu12ThsKgy.STARTYMD
                ,RepaVbjaMeu12ThsKgy.SNSTNT
                ,RepaVbjaMeu12ThsKgy.THSKGYKN
                ,RepaVbjaMeu12ThsKgy.THSKGYSRCHKN
                ,RepaVbjaMeu12ThsKgy.THSKGYEN
                ,RepaVbjaMeu12ThsKgy.THSKGYDISPKJ
                ,RepaVbjaMeu12ThsKgy.THSKGYLNGKJ
                ,RepaVbjaMeu12ThsKgy.KGYGSYLCD
                ,RepaVbjaMeu12ThsKgy.SYUYOU
                ,RepaVbjaMeu12ThsKgy.POST
                ,RepaVbjaMeu12ThsKgy.ADDRESS
                ,RepaVbjaMeu12ThsKgy.KGYOZOK
                ,RepaVbjaMeu12ThsKgy.KJNHJNKBN
                ,RepaVbjaMeu12ThsKgy.CNTRY
                ,RepaVbjaMeu12ThsKgy.LANG
                ,RepaVbjaMeu12ThsKgy.CHOSYM
                ,RepaVbjaMeu12ThsKgy.GNSKBN
                ,RepaVbjaMeu12ThsKgy.GNSSTAYMD
                ,RepaVbjaMeu12ThsKgy.GNSENDYMD
                ,RepaVbjaMeu12ThsKgy.GAISIKBN
                ,RepaVbjaMeu12ThsKgy.CM10CDCLNTCD
                ,RepaVbjaMeu12ThsKgy.DELNGFLG
                ,RepaVbjaMeu12ThsKgy.AORKGY
                ,RepaVbjaMeu12ThsKgy.FEEKGY
                ,RepaVbjaMeu12ThsKgy.DTENKBN
                ,RepaVbjaMeu12ThsKgy.AREADENTSUKBN
                ,RepaVbjaMeu12ThsKgy.SIHONKIN
                ,RepaVbjaMeu12ThsKgy.KJNINFOHGKBN
                ,RepaVbjaMeu12ThsKgy.KSNM
                ,RepaVbjaMeu12ThsKgy.DUMMYKBN
        };
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        //*******************************************
        //selectVOで使用されるSQL
        //*******************************************
        //SELECT + FROM句
        sql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append((i != 0 ? " ," : " "));
            sql.append("" + getTableColumnNames()[i] +" ");
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        //WHERE句
        sql.append(generateWhereByCond(getModel()));

        return sql.toString();
    };

    /**
     * 値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo) {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }

                if (getTableColumnNames()[i].equals(RepaVbjaMeu12ThsKgy.ENDYMD)) {
                    sql.append(getTableColumnNames()[i] + " >= " + getDBModelInterface().ConvertToDBString(value));
                } else if (getTableColumnNames()[i].equals(RepaVbjaMeu12ThsKgy.STARTYMD)) {
                    sql.append(getTableColumnNames()[i] + " <= " + getDBModelInterface().ConvertToDBString(value));
                } else {
                    sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
                }
            }
        }

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu12ThsKgyVO> selectVO(RepaVbjaMeu12ThsKgyVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            return (List<RepaVbjaMeu12ThsKgyVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
