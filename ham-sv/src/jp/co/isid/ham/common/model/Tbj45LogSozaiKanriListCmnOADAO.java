package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj45LogSozaiKanriListCmnOA;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧（共有OA期間）ログDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/29 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj45LogSozaiKanriListCmnOADAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj45LogSozaiKanriListCmnOACondition _condition = null;

    /** SqlMode */
    private enum SqlMode {DEFAULT, MAXSOZAIYM};

    /** 選択SQLモード変数 */
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj45LogSozaiKanriListCmnOADAO() {
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
                Tbj45LogSozaiKanriListCmnOA.DCARCD
                ,Tbj45LogSozaiKanriListCmnOA.SOZAIYM
                ,Tbj45LogSozaiKanriListCmnOA.RECKBN
                ,Tbj45LogSozaiKanriListCmnOA.HISTORYNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj45LogSozaiKanriListCmnOA.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj45LogSozaiKanriListCmnOA.CRTDATE
                ,Tbj45LogSozaiKanriListCmnOA.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj45LogSozaiKanriListCmnOA.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj45LogSozaiKanriListCmnOA.DCARCD
                ,Tbj45LogSozaiKanriListCmnOA.SOZAIYM
                ,Tbj45LogSozaiKanriListCmnOA.RECKBN
                ,Tbj45LogSozaiKanriListCmnOA.RECNO
                ,Tbj45LogSozaiKanriListCmnOA.HISTORYNO
                ,Tbj45LogSozaiKanriListCmnOA.HISTORYKBN
                ,Tbj45LogSozaiKanriListCmnOA.DELFLG
                ,Tbj45LogSozaiKanriListCmnOA.CMCD
                ,Tbj45LogSozaiKanriListCmnOA.TEMPCMCD
                ,Tbj45LogSozaiKanriListCmnOA.OADATETERM
                ,Tbj45LogSozaiKanriListCmnOA.CRTDATE
                ,Tbj45LogSozaiKanriListCmnOA.CRTNM
                ,Tbj45LogSozaiKanriListCmnOA.CRTAPL
                ,Tbj45LogSozaiKanriListCmnOA.CRTID
                ,Tbj45LogSozaiKanriListCmnOA.UPDDATE
                ,Tbj45LogSozaiKanriListCmnOA.UPDNM
                ,Tbj45LogSozaiKanriListCmnOA.UPDAPL
                ,Tbj45LogSozaiKanriListCmnOA.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            sql = getSelectSQLTbj45LogSozaiKanriListCmnOA();
        } else if (_sqlMode.equals(SqlMode.MAXSOZAIYM)) {
            //素材年月の最大値取得
            sql = getMaxSozaiYm();
        }

        return sql;
    };

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
     * SELECT SQL(Tbj45LogSozaiKanriListCmnOA)
     */
    private String getSelectSQLTbj45LogSozaiKanriListCmnOA() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        selectSql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null) {
            Tbj45LogSozaiKanriListCmnOAVO vo = new Tbj45LogSozaiKanriListCmnOAVO();
            vo.setCMCD(_condition.getCmcd());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setDELFLG(_condition.getDelflg());
            vo.setRECKBN(_condition.getReckbn());
            vo.setRECNO(_condition.getRecno());
            vo.setSOZAIYM(_condition.getSozaiym());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setCRTAPL(_condition.getCrtapl());
            vo.setCRTDATE(_condition.getCrtdate());
            vo.setCRTID(_condition.getCrtid());
            vo.setCRTNM(_condition.getCrtnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDID(_condition.getUpdid());
            vo.setUPDNM(_condition.getUpdnm());

            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY");
        orderSql.append(" " + Tbj45LogSozaiKanriListCmnOA.HISTORYNO);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };
    
    /**
     * 素材年月の最大値取得用SQL作成
     * @return String SQL文
     */
    private String getMaxSozaiYm() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        sql.append(" MAX(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + ") + 1 / 86400 " + Tbj45LogSozaiKanriListCmnOA.SOZAIYM);

        sql.append(" FROM");
        sql.append(" "+ Tbj45LogSozaiKanriListCmnOA.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.DCARCD + " = '" + _condition.getDcarcd() + "' AND");
        sql.append(" TO_CHAR(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + ", 'YYYYMMDD') = '" + DateUtil.toString(_condition.getSozaiym()) + "' AND");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.RECKBN + " = '" + _condition.getReckbn() + "'");

        return sql.toString();
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj45LogSozaiKanriListCmnOAVO> selectVO(Tbj45LogSozaiKanriListCmnOACondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj45LogSozaiKanriListCmnOAVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * deleteVO
     * @param vo 削除VO
     * @throws HAMException
     */
    public void deleteVO(Tbj45LogSozaiKanriListCmnOAVO vo) throws HAMException {

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
     * 素材年月の最大値取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj45LogSozaiKanriListCmnOAVO> findMaxSozaiYm(Tbj45LogSozaiKanriListCmnOACondition cond) throws HAMException {

        super.setModel(new Tbj45LogSozaiKanriListCmnOAVO());

        try {
            _sqlMode = SqlMode.MAXSOZAIYM;
            _condition = cond;
            return (List<Tbj45LogSozaiKanriListCmnOAVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}