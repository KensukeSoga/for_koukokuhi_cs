package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj30DisplayPattern;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 一覧表示パターンDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj30DisplayPatternDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj30DisplayPatternCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj30DisplayPatternDAO() {
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
                Tbj30DisplayPattern.HAMID
                ,Tbj30DisplayPattern.FORMID
                ,Tbj30DisplayPattern.VIEWID
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj30DisplayPattern.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj30DisplayPattern.CRTDATE
                ,Tbj30DisplayPattern.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj30DisplayPattern.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj30DisplayPattern.HAMID
                ,Tbj30DisplayPattern.FORMID
                ,Tbj30DisplayPattern.VIEWID
                ,Tbj30DisplayPattern.VIEWDISPPATTERN
                ,Tbj30DisplayPattern.CRTDATE
                ,Tbj30DisplayPattern.CRTNM
                ,Tbj30DisplayPattern.CRTAPL
                ,Tbj30DisplayPattern.CRTID
                ,Tbj30DisplayPattern.UPDDATE
                ,Tbj30DisplayPattern.UPDNM
                ,Tbj30DisplayPattern.UPDAPL
                ,Tbj30DisplayPattern.UPDID
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
    public String getSelectSQL()
    {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        //*******************************************
        //load()、find()で使用されるSELECT + FROM句のSQL
        //*******************************************
        selectSql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }
        selectSql.append(" FROM ");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null)
        {   // 検索条件で有効なもの
            // HAMID
            // FORMID
            // VIEWID
            Tbj30DisplayPatternVO vo = new Tbj30DisplayPatternVO();
            vo.setHAMID(_condition.getHamid());
            vo.setFORMID(_condition.getFormid());
            vo.setVIEWID(_condition.getViewid());
            whereSqlStr = generateWhereByCond(vo);

        }

        return selectSql.toString() + whereSqlStr + orderSql.toString();

    };

    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj30DisplayPatternVO loadVO(Tbj30DisplayPatternVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj30DisplayPatternVO)super.load();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }




    @Override
    public String getExecString() {
        String sql = "";
        sql = getInsertSql();
        return sql;
    }

    private String getInsertSql() {
        StringBuffer sql = new StringBuffer();

        Tbj30DisplayPatternVO vo = (Tbj30DisplayPatternVO)super.getModel();

        sql.append(" INSERT INTO " + Tbj30DisplayPattern.TBNAME + " ( ");
        sql.append(" " + Tbj30DisplayPattern.HAMID + ", ");
        sql.append(" " + Tbj30DisplayPattern.FORMID + ", ");
        sql.append(" " + Tbj30DisplayPattern.VIEWID + ", ");
        sql.append(" " + Tbj30DisplayPattern.VIEWDISPPATTERN + ", ");
        sql.append(" " + Tbj30DisplayPattern.CRTDATE + ", ");
        sql.append(" " + Tbj30DisplayPattern.CRTNM + ", ");
        sql.append(" " + Tbj30DisplayPattern.CRTAPL + ", ");
        sql.append(" " + Tbj30DisplayPattern.CRTID + ", ");
        sql.append(" " + Tbj30DisplayPattern.UPDDATE + ", ");
        sql.append(" " + Tbj30DisplayPattern.UPDNM + ", ");
        sql.append(" " + Tbj30DisplayPattern.UPDAPL + ", ");
        sql.append(" " + Tbj30DisplayPattern.UPDID + " ");
        sql.append(" ) VALUES ( ");
        sql.append(" '" + vo.getHAMID() + "', ");
        sql.append(" '" + vo.getFORMID() + "', ");
        sql.append(" '" + vo.getVIEWID() + "', ");
        sql.append(" ");
        if (vo.getVIEWDISPPATTERN().length() > 1000) {
            int sLen = 0;
            int eLen = 0;
            while(vo.getVIEWDISPPATTERN().length() > sLen) {

                if (sLen + 1000 > vo.getVIEWDISPPATTERN().length()) {
                    eLen = vo.getVIEWDISPPATTERN().length();
                    sql.append("TO_CLOB('" + vo.getVIEWDISPPATTERN().substring(sLen, eLen) + "')" );
                } else {
                    eLen = sLen + 1000;
                    sql.append("TO_CLOB('" + vo.getVIEWDISPPATTERN().substring(sLen, eLen) + "') || " );
                }

                sLen = eLen;
            }
        } else {
            sql.append(" '" + vo.getVIEWDISPPATTERN() + "' ");
        }
        sql.append(", ");
        sql.append(" SYSDATE, ");
        sql.append(" '" + vo.getCRTNM() + "', ");
        sql.append(" '" + vo.getCRTAPL() + "', ");
        sql.append(" '" + vo.getCRTID() + "', ");
        sql.append(" SYSDATE, ");
        sql.append(" '" + vo.getUPDNM() + "', ");
        sql.append(" '" + vo.getUPDAPL() + "', ");
        sql.append(" '" + vo.getUPDID() + "' ");
        sql.append(" ) ");

        return sql.toString();
    }

    /**
     * 登録
     * @param vo
     * @return
     * @throws HAMException
     */
    public void insertVO(Tbj30DisplayPatternVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            //super.insert();
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * PK更新
     * @param vo
     * @return
     * @throws HAMException
     */
    public void updateVO(Tbj30DisplayPatternVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            super.update();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * PK削除
     * @param vo
     * @return
     * @throws HAMException
     */
    public void deleteVO(Tbj30DisplayPatternVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            super.remove();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }



    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj30DisplayPatternVO> selectVO(Tbj30DisplayPatternCondition condition) throws HAMException
    {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj30DisplayPatternVO());
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
