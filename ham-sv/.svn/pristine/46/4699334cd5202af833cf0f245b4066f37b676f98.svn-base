package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 経理組織展開テーブルDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu07SikKrSprdDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private RepaVbjaMeu07SikKrSprdCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        DATE,
    };
    private SelSqlMode _SelSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu07SikKrSprdDAO() {
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
        return RepaVbjaMeu07SikKrSprd.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu07SikKrSprd.SIKCD
                ,RepaVbjaMeu07SikKrSprd.ENDYMD
                ,RepaVbjaMeu07SikKrSprd.STARTYMD
                ,RepaVbjaMeu07SikKrSprd.KRIKAISOCD
                ,RepaVbjaMeu07SikKrSprd.KRIJSIKCD
                ,RepaVbjaMeu07SikKrSprd.CKATUKBN
                ,RepaVbjaMeu07SikKrSprd.JYTRKKBN
                ,RepaVbjaMeu07SikKrSprd.ODRTRKKBN
                ,RepaVbjaMeu07SikKrSprd.KNRIBMON
                ,RepaVbjaMeu07SikKrSprd.KSHATHSCD
                ,RepaVbjaMeu07SikKrSprd.KSHATHSSEQNO
                ,RepaVbjaMeu07SikKrSprd.KYUTRCD
                ,RepaVbjaMeu07SikKrSprd.BCKKBN
                ,RepaVbjaMeu07SikKrSprd.EGSYOCD
                ,RepaVbjaMeu07SikKrSprd.SHOWNO
                ,RepaVbjaMeu07SikKrSprd.JSIKHYOJIJUN
                ,RepaVbjaMeu07SikKrSprd.HYOJIKN
                ,RepaVbjaMeu07SikKrSprd.HYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.HYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.HYOJIEN
                ,RepaVbjaMeu07SikKrSprd.KSHASKBTUCD
                ,RepaVbjaMeu07SikKrSprd.IOCD
                ,RepaVbjaMeu07SikKrSprd.SPUSECD
                ,RepaVbjaMeu07SikKrSprd.SIKCDHONB
                ,RepaVbjaMeu07SikKrSprd.HONBHYOJIKN
                ,RepaVbjaMeu07SikKrSprd.HONBHYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.HONBHYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.HONBHYOJIEN
                ,RepaVbjaMeu07SikKrSprd.SIKCDKYK
                ,RepaVbjaMeu07SikKrSprd.KYKHYOJIKN
                ,RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.KYKHYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.KYKHYOJIEN
                ,RepaVbjaMeu07SikKrSprd.SIKCDSITU
                ,RepaVbjaMeu07SikKrSprd.SITUHYOJIKN
                ,RepaVbjaMeu07SikKrSprd.SITUHYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.SITUHYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.SITUHYOJIEN
                ,RepaVbjaMeu07SikKrSprd.SIKCDBU
                ,RepaVbjaMeu07SikKrSprd.BUHYOJIKN
                ,RepaVbjaMeu07SikKrSprd.BUHYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.BUHYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.BUHYOJIEN
                ,RepaVbjaMeu07SikKrSprd.SIKCDKA
                ,RepaVbjaMeu07SikKrSprd.KAHYOJIKN
                ,RepaVbjaMeu07SikKrSprd.KAHYOJIKJ
                ,RepaVbjaMeu07SikKrSprd.KAHYOJIRYAKU
                ,RepaVbjaMeu07SikKrSprd.KAHYOJIEN
        };
    }

//    /**
//     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
//     * @param vo
//     * @return
//     */
//    private String generateWhereByCond(AbstractModel vo)
//    {
//        StringBuffer sql = new StringBuffer();
//
//        for (int i = 0; i < getTableColumnNames().length; i++) {
//            if (vo.getUpdateMember().containsKey(getTableColumnNames()[i])) {
//                Object value = vo.get(getTableColumnNames()[i]);
//                if (sql.length() == 0) {
//                    sql.append(" WHERE ");
//                } else {
//                    sql.append(" AND ");
//                }
//                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
//            }
//        }
//
//        return sql.toString();
//    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCondForDATE(AbstractModel vo)
    {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (vo.getUpdateMember().containsKey(getTableColumnNames()[i])) {
                Object value = vo.get(getTableColumnNames()[i]);
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                if (getTableColumnNames()[i].equals(RepaVbjaMeu07SikKrSprd.STARTYMD)) {
                    sql.append(getTableColumnNames()[i] + " <= " + getDBModelInterface().ConvertToDBString(value));
                } else if (getTableColumnNames()[i].equals(RepaVbjaMeu07SikKrSprd.ENDYMD)) {
                    sql.append(getTableColumnNames()[i] + " >= " + getDBModelInterface().ConvertToDBString(value));
                } else {
                    sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
                }
            }
        }

        return sql.toString();
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        String sql = "";

        if (SelSqlMode.DATE.equals(_SelSqlMode)) {
            sql = getSelectSQLForDATE();
        }

        return sql;
    };

    /**
     * ModeがDATEの場合のSQL文を返します
     * @return
     */
    private String getSelectSQLForDATE() {
        StringBuffer sql = new StringBuffer();
        StringBuffer sqlSelect = new StringBuffer();
        StringBuffer sqlWhere = new StringBuffer();
        StringBuffer sqlOrder = new StringBuffer();


        sqlSelect.append("SELECT ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sqlSelect.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sqlSelect.append(", ");
            }
        }
        sqlSelect.append(" FROM ");
        sqlSelect.append(getTableName());
        //WHERE句
        RepaVbjaMeu07SikKrSprdVO condVo = (RepaVbjaMeu07SikKrSprdVO)getModel();
        sqlSelect.append(generateWhereByCondForDATE(condVo));


        sql.append(sqlSelect);
        sql.append(sqlWhere);
        sql.append(sqlOrder);
        return sql.toString();
    }

    /**
     * 指定した条件で検索を行います
     * ただし有効開始年月日、有効終了年月日については範囲指定で検索します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu07SikKrSprdVO> selectVoByDate(RepaVbjaMeu07SikKrSprdVO vo) throws HAMException {
        // パラメータチェック
        if (vo == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            _SelSqlMode = SelSqlMode.DATE;
            return (List<RepaVbjaMeu07SikKrSprdVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
