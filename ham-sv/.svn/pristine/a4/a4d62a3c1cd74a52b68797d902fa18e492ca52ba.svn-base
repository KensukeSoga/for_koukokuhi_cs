package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj26LogSozaiKanriList;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧変更ログDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/03/09 HDX対応 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj26LogSozaiKanriListDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj26LogSozaiKanriListCondition _condition = null;

    /** SqlMode */
    private enum SqlMode {DEFAULT, MAXHISTORYNO};

    /** 選択SQLモード変数 */
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /** デフォルトコンストラクタ*/
    public Tbj26LogSozaiKanriListDAO() {
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
                Tbj26LogSozaiKanriList.DCARCD
                ,Tbj26LogSozaiKanriList.SOZAIYM
                ,Tbj26LogSozaiKanriList.RECKBN
                ,Tbj26LogSozaiKanriList.RECNO
                ,Tbj26LogSozaiKanriList.HISTORYNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj26LogSozaiKanriList.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj26LogSozaiKanriList.CRTDATE
                ,Tbj26LogSozaiKanriList.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj26LogSozaiKanriList.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj26LogSozaiKanriList.DCARCD
                ,Tbj26LogSozaiKanriList.SOZAIYM
                ,Tbj26LogSozaiKanriList.RECKBN
                ,Tbj26LogSozaiKanriList.RECNO
                ,Tbj26LogSozaiKanriList.HISTORYNO
                ,Tbj26LogSozaiKanriList.HISTORYKBN
                ,Tbj26LogSozaiKanriList.DELFLG
                ,Tbj26LogSozaiKanriList.CMCD
                ,Tbj26LogSozaiKanriList.TEMPCMCD
                ,Tbj26LogSozaiKanriList.TITLE
                ,Tbj26LogSozaiKanriList.SECOND
                ,Tbj26LogSozaiKanriList.RCODE
                ,Tbj26LogSozaiKanriList.ESTIMATE
                ,Tbj26LogSozaiKanriList.DATEFROM
                ,Tbj26LogSozaiKanriList.DATEFROM_ATTR
                ,Tbj26LogSozaiKanriList.DATETO
                ,Tbj26LogSozaiKanriList.DATETO_ATTR
                ,Tbj26LogSozaiKanriList.NEWFLG
                ,Tbj26LogSozaiKanriList.NEWDISPFLG
                ,Tbj26LogSozaiKanriList.TIMEUSE
                ,Tbj26LogSozaiKanriList.SPOTUSE
                ,Tbj26LogSozaiKanriList.SPOTCTRT
                ,Tbj26LogSozaiKanriList.SPOTSPAN
                ,Tbj26LogSozaiKanriList.SPOTESTM
                ,Tbj26LogSozaiKanriList.LIMIT
                ,Tbj26LogSozaiKanriList.SYATAN
                ,Tbj26LogSozaiKanriList.HCSYATAN
                ,Tbj26LogSozaiKanriList.HMSYATAN
                ,Tbj26LogSozaiKanriList.BIKO
                ,Tbj26LogSozaiKanriList.OPENFLG
                ,Tbj26LogSozaiKanriList.CRTDATE
                ,Tbj26LogSozaiKanriList.CRTNM
                ,Tbj26LogSozaiKanriList.CRTAPL
                ,Tbj26LogSozaiKanriList.CRTID
                ,Tbj26LogSozaiKanriList.UPDDATE
                ,Tbj26LogSozaiKanriList.UPDNM
                ,Tbj26LogSozaiKanriList.UPDAPL
                ,Tbj26LogSozaiKanriList.UPDID
        };
    }

    /** SELECT SQL */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            sql = getSelectSQLTbj26LogSozaiKanriList();
        }else if (_sqlMode.equals(SqlMode.MAXHISTORYNO)) {
            sql = getSelectSQLMaxHistoryNo();
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
     * SELECT SQL(Tbj26LogSozaiKanriList)
     */
    private String getSelectSQLTbj26LogSozaiKanriList() {

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
            Tbj26LogSozaiKanriListVO vo = new Tbj26LogSozaiKanriListVO();
            vo.setDCARCD(_condition.getDcarcd());
            vo.setCMCD(_condition.getCmcd());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setSOZAIYM(_condition.getSozaiym());
            vo.setRECKBN(_condition.getReckbn());
            vo.setRECNO(_condition.getRecno());
            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY");
        orderSql.append(" " + Tbj26LogSozaiKanriList.CRTDATE);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * 最大履歴番号検索用SQL作成
     * @return String SQL文
     */
    private String getSelectSQLMaxHistoryNo() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        sql.append(" NVL(MAX(" + Tbj26LogSozaiKanriList.HISTORYNO + "), 0)" + Tbj26LogSozaiKanriList.HISTORYNO);

        sql.append(" FROM ");
        sql.append(" " + Tbj26LogSozaiKanriList.TBNAME);

        sql.append(" WHERE");
        //10桁CMコードがNULLの場合
        if(_condition.getCmcd().length() > 0){
            sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " = '" + _condition.getCmcd() + "' AND");
        }else{
            sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " IS NULL AND");
        }
        //仮10桁CMコードがNULLの場合
        if(_condition.getTempcmcd().length() > 0){
            sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = '" + _condition.getTempcmcd() + "' AND");
        }else{
            sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " IS NULL AND");
        }
        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = '" + DateUtil.toString(_condition.getSozaiym()) + "' AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = '" + _condition.getReckbn() + "'");

        return sql.toString();
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj26LogSozaiKanriListVO>selectVO(Tbj26LogSozaiKanriListCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj26LogSozaiKanriListVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 最大履歴番号検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj26LogSozaiKanriListVO> FindMaxHistoryNo(Tbj26LogSozaiKanriListCondition cond) throws HAMException {

        super.setModel(new Tbj26LogSozaiKanriListVO());

        try {
            _sqlMode = SqlMode.MAXHISTORYNO;
            _condition = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}