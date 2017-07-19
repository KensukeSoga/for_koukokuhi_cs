package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu29Cc;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 共通コードマスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class RepaVbjaMeu29CcDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private RepaVbjaMeu29CcCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{COND, CD};
    private SelSqlMode _SelSqlMode = SelSqlMode.COND;


    /** コードを保持 */
    private String _code = null;

    /** 内容J？を保持 */
    private String _naiyoJ = null;

    /** 廃止年月 */
    private static String ENDYM = "99999999";

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu29CcDAO() {
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
        return RepaVbjaMeu29Cc.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
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
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        if (_SelSqlMode.equals(SelSqlMode.COND)) {
            return getCodeMasterByCond();
        } else if (_SelSqlMode.equals(SelSqlMode.CD)) {
            return getCodeMasterByCd();
        } else {
            return null;
        }
    }

    /**
     * 指定した条件に従って検索するSQL文を取得する
     *
     * @return SQL文
     */
    private String getCodeMasterByCond() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";

        selectSql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM ");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null)
        {
            RepaVbjaMeu29CcVO vo = new RepaVbjaMeu29CcVO();
            vo.setKYCDKND(_condition.getKycdknd());
            vo.setKYCD(_condition.getKycd());
            vo.setHKYMD(_condition.getHkymd());
            vo.setHAISYMD(_condition.getHaisymd());
            vo.setNAIYKN(_condition.getNaiykn());
            vo.setNAIYJ(_condition.getNaiyj());
            vo.setYOBI1(_condition.getYobi1());
            vo.setHOSOK(_condition.getHosok());
            vo.setYOBI2(_condition.getYobi2());
            whereSqlStr = generateWhereByCond(vo);
        }

        return selectSql.toString() + whereSqlStr;
    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
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
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * キーコード検索を行う
     * @return SQL文
     */
    private String getCodeMasterByCd() {

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
        sql.append(" " + RepaVbjaMeu29Cc.KYCDKND + " IN(" + _code + ") ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu29Cc.NAIYJ + " LIKE('%" + _naiyoJ + "%') ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu29Cc.HAISYMD + " ='" + ENDYM + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + RepaVbjaMeu29Cc.KYCDKND + " ASC, ");
        sql.append(" " + RepaVbjaMeu29Cc.KYCD + " ASC ");

        return sql.toString();
    }

    /**
     * キーコード検索を行う
     * @param code 検索対象のコード
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu29CcVO> FindCodeMasterByCode(String code,String naiyoJ) throws HAMException {

        super.setModel(new RepaVbjaMeu29CcVO());

        try {
            _code = code;
            _naiyoJ = naiyoJ;
            _SelSqlMode = SelSqlMode.CD;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<RepaVbjaMeu29CcVO> selectVO(RepaVbjaMeu29CcCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new RepaVbjaMeu29CcVO());
        try {
            _SelSqlMode = SelSqlMode.COND;
            _condition = condition;
            return (List<RepaVbjaMeu29CcVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
