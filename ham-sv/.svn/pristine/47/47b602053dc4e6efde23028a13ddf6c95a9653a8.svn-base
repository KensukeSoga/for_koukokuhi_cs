package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Vbj01AccUser;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 新HAM向けVIEW(個人情報)DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Vbj01AccUserDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Vbj01AccUserCondition _condition = null;
    private List<Vbj01AccUserCondition> _conditionList = null;

    private enum SelSqlMode{DEF, ESQID5, MAIL, KK, }
    private SelSqlMode _selSqlMode = SelSqlMode.DEF;

    /**
     * デフォルトコンストラクタ
     */
    public Vbj01AccUserDAO() {
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
        return Vbj01AccUser.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Vbj01AccUser.ESQID
                ,Vbj01AccUser.POSTSTATE
                ,Vbj01AccUser.CN
                ,Vbj01AccUser.SIKOGNZUNTCD
                ,Vbj01AccUser.MAIL
                ,Vbj01AccUser.HBSIKOGNZUNTCD
                ,Vbj01AccUser.HBOU
                ,Vbj01AccUser.KKSIKOGNZUNTCD
                ,Vbj01AccUser.KKOU
                ,Vbj01AccUser.HTSIKOGNZUNTCD
                ,Vbj01AccUser.HTOU
                ,Vbj01AccUser.BUSIKOGNZUNTCD
                ,Vbj01AccUser.BUOU
                ,Vbj01AccUser.KASIKOGNZUNTCD
                ,Vbj01AccUser.KAOU
        };
    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo)
    {
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
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sqlSelect = new StringBuffer();
        String whereSqlStr = "";

        if (_selSqlMode.equals(SelSqlMode.DEF)) {

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

            if (_condition != null) {
                Vbj01AccUserVO vo = new Vbj01AccUserVO();
                vo.setESQID(_condition.getEsqid());
                vo.setPOSTSTATE(_condition.getPoststate());
                vo.setCN(_condition.getCn());
                vo.setSIKOGNZUNTCD(_condition.getSikognzuntcd());
                vo.setMAIL(_condition.getMail());
                vo.setHBSIKOGNZUNTCD(_condition.getHbsikognzuntcd());
                vo.setHBOU(_condition.getHbou());
                vo.setKKSIKOGNZUNTCD(_condition.getKksikognzuntcd());
                vo.setKKOU(_condition.getKkou());
                vo.setHTSIKOGNZUNTCD(_condition.getHtsikognzuntcd());
                vo.setHTOU(_condition.getHtou());
                vo.setBUSIKOGNZUNTCD(_condition.getBusikognzuntcd());
                vo.setBUOU(_condition.getBuou());
                vo.setKASIKOGNZUNTCD(_condition.getKasikognzuntcd());
                vo.setKAOU(_condition.getKaou());
                whereSqlStr = generateWhereByCond(vo);
            }

        } else if (_selSqlMode.equals(SelSqlMode.ESQID5)) {

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
            sqlSelect.append(" WHERE ");
            sqlSelect.append(" " + Vbj01AccUser.ESQID + " LIKE '_" + _condition.getEsqid() + "' ");

        } else if (_selSqlMode.equals(SelSqlMode.MAIL)) {

            sqlSelect.append("SELECT ");
            sqlSelect.append("  ").append(Vbj01AccUser.ESQID);
            sqlSelect.append(" ,").append(Vbj01AccUser.CN);
            sqlSelect.append(" ,").append(Vbj01AccUser.MAIL);
            sqlSelect.append(" FROM ");
            sqlSelect.append(getTableName());
            sqlSelect.append(" WHERE ");
            sqlSelect.append(" " + Vbj01AccUser.ESQID + " IN (");
            for (int i = 0; i < _conditionList.size(); i++) {
                if (i > 0) {
                    sqlSelect.append(", ");
                }
                sqlSelect.append(getDBModelInterface().ConvertToDBString(_conditionList.get(i).getEsqid()));
            }
            sqlSelect.append(" ) ");
            sqlSelect.append(" GROUP BY ");
            sqlSelect.append("  ").append(Vbj01AccUser.ESQID);
            sqlSelect.append(" ,").append(Vbj01AccUser.CN);
            sqlSelect.append(" ,").append(Vbj01AccUser.MAIL);

        } else if (_selSqlMode.equals(SelSqlMode.KK)) {

            sqlSelect.append("SELECT ");

            sqlSelect.append(" " + Vbj01AccUser.ESQID + " ");
            sqlSelect.append("," + Vbj01AccUser.CN + " ");
            sqlSelect.append("," + Vbj01AccUser.MAIL + " ");
            sqlSelect.append("," + Vbj01AccUser.KKSIKOGNZUNTCD + " ");
            sqlSelect.append("," + Vbj01AccUser.KKOU + " ");

            sqlSelect.append(" FROM ");
            sqlSelect.append(getTableName());
            sqlSelect.append(" WHERE ");
            for (int i = 0; i < _conditionList.size(); i++) {
                if (i > 0) {
                    sqlSelect.append(" OR ");
                }
                sqlSelect.append(" ( ");
                sqlSelect.append(" " + Vbj01AccUser.ESQID + " = ");
                sqlSelect.append(getDBModelInterface().ConvertToDBString(_conditionList.get(i).getEsqid()));
                sqlSelect.append(" ) ");
            }
            sqlSelect.append(" GROUP BY ");
            sqlSelect.append(" " + Vbj01AccUser.ESQID + " ");
            sqlSelect.append("," + Vbj01AccUser.CN + " ");
            sqlSelect.append("," + Vbj01AccUser.MAIL + " ");
            sqlSelect.append("," + Vbj01AccUser.KKSIKOGNZUNTCD + " ");
            sqlSelect.append("," + Vbj01AccUser.KKOU + " ");
            sqlSelect.append(" ORDER BY ");
            sqlSelect.append(" " + Vbj01AccUser.ESQID + " ");
        }

        return sqlSelect.toString() + whereSqlStr;
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Vbj01AccUserVO> selectVO(Vbj01AccUserCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Vbj01AccUserVO());

        try {
            _condition = condition;
            return (List<Vbj01AccUserVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ESQID(5桁)で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Vbj01AccUserVO> selectByEsqId5(Vbj01AccUserCondition condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Vbj01AccUserVO());

        try {
            _condition = condition;
            _selSqlMode = SelSqlMode.ESQID5;
            return (List<Vbj01AccUserVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Vbj01AccUserVO> selectForEachKK(List<Vbj01AccUserCondition> condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Vbj01AccUserVO());

        try {
            _conditionList = condition;
            _selSqlMode = SelSqlMode.KK;
            return (List<Vbj01AccUserVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * IDでIN検索を行い、メールアドレスを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Vbj01AccUserVO> selectMail(List<Vbj01AccUserCondition> condition) throws HAMException {

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Vbj01AccUserVO());

        try {
            _conditionList = condition;
            _selSqlMode = SelSqlMode.MAIL;
            return (List<Vbj01AccUserVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
