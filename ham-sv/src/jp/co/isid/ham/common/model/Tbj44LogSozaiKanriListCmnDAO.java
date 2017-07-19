package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj44LogSozaiKanriListCmn;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材一覧（共有）ログDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/03/10 HDX対応 K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj44LogSozaiKanriListCmnDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj44LogSozaiKanriListCmnCondition _condition = null;

    /** 登録データ */
    private Tbj44LogSozaiKanriListCmnVO _vo = null;

    /** SqlMode */
    private enum SqlMode {DEFAULT, DEL};

    /** 選択SQLモード変数 */
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /** デフォルトコンストラクタ */
    public Tbj44LogSozaiKanriListCmnDAO() {
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
                Tbj44LogSozaiKanriListCmn.DCARCD
                ,Tbj44LogSozaiKanriListCmn.SOZAIYM
                ,Tbj44LogSozaiKanriListCmn.RECKBN
                ,Tbj44LogSozaiKanriListCmn.RECNO
                ,Tbj44LogSozaiKanriListCmn.HISTORYNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj44LogSozaiKanriListCmn.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj44LogSozaiKanriListCmn.CRTDATE
                ,Tbj44LogSozaiKanriListCmn.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj44LogSozaiKanriListCmn.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj44LogSozaiKanriListCmn.DCARCD
                ,Tbj44LogSozaiKanriListCmn.SOZAIYM
                ,Tbj44LogSozaiKanriListCmn.RECKBN
                ,Tbj44LogSozaiKanriListCmn.RECNO
                ,Tbj44LogSozaiKanriListCmn.HISTORYNO
                ,Tbj44LogSozaiKanriListCmn.HISTORYKBN
                ,Tbj44LogSozaiKanriListCmn.DELFLG
                ,Tbj44LogSozaiKanriListCmn.CMCD
                ,Tbj44LogSozaiKanriListCmn.TEMPCMCD
                ,Tbj44LogSozaiKanriListCmn.ALIASTITLE
                ,Tbj44LogSozaiKanriListCmn.ENDTITLE
                ,Tbj44LogSozaiKanriListCmn.BSCSUSE
                ,Tbj44LogSozaiKanriListCmn.TIMEUSE
                ,Tbj44LogSozaiKanriListCmn.SPOTUSE
                ,Tbj44LogSozaiKanriListCmn.SPOTCTRT
                ,Tbj44LogSozaiKanriListCmn.SPOTFROM
                ,Tbj44LogSozaiKanriListCmn.SPOTTO
                ,Tbj44LogSozaiKanriListCmn.HMORDER
                ,Tbj44LogSozaiKanriListCmn.LAYOUTORDER
                ,Tbj44LogSozaiKanriListCmn.OANGSPAN
                ,Tbj44LogSozaiKanriListCmn.TARGET
                ,Tbj44LogSozaiKanriListCmn.CARNEWS
                ,Tbj44LogSozaiKanriListCmn.NEXTCARNEWS
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MVCHL
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MXTV
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_FMJPN
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_WTCC
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER1
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER2
                ,Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER3
                ,Tbj44LogSozaiKanriListCmn.CRTDATE
                ,Tbj44LogSozaiKanriListCmn.CRTNM
                ,Tbj44LogSozaiKanriListCmn.CRTAPL
                ,Tbj44LogSozaiKanriListCmn.CRTID
                ,Tbj44LogSozaiKanriListCmn.UPDDATE
                ,Tbj44LogSozaiKanriListCmn.UPDNM
                ,Tbj44LogSozaiKanriListCmn.UPDAPL
                ,Tbj44LogSozaiKanriListCmn.UPDID
        };
    }

    /** SELECT SQL */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            sql = getSelectSQLTbj44LogSozaiKanriListCmn();
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

    /** SELECT SQL(Tbj44LogSozaiKanriListCmn) */
    private String getSelectSQLTbj44LogSozaiKanriListCmn() {

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
            Tbj44LogSozaiKanriListCmnVO vo = new Tbj44LogSozaiKanriListCmnVO();
            vo.setDCARCD(_condition.getDcarcd());
            vo.setCMCD(_condition.getCmcd());
            vo.setTEMPCMCD(_condition.getTempcmcd());
            vo.setSOZAIYM(_condition.getSozaiym());
            vo.setRECKBN(_condition.getReckbn());
            vo.setRECNO(_condition.getRecno());
            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY");
        orderSql.append(" " + Tbj44LogSozaiKanriListCmn.CRTDATE);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {

        StringBuffer sql = new StringBuffer();


        //素材一覧(共通)ログ削除
        if (_sqlMode.equals(SqlMode.DEL)) {

            sql.append("DELETE");
            sql.append(" FROM");
            sql.append(" " + Tbj44LogSozaiKanriListCmn.TBNAME);

            sql.append(" WHERE");
            //本素材
            if(_vo.getCMCD() != null){
                sql.append(" " + Tbj44LogSozaiKanriListCmn.CMCD + " = '" + _vo.getCMCD() + "' AND");
            }else{
                sql.append(" " + Tbj44LogSozaiKanriListCmn.CMCD + " IS NULL AND");
            }
            //仮素材
            if(_vo.getTEMPCMCD() != null){
                sql.append(" " + Tbj44LogSozaiKanriListCmn.TEMPCMCD + " = '" + _vo.getTEMPCMCD() + "'");
            }else{
                sql.append(" " + Tbj44LogSozaiKanriListCmn.TEMPCMCD + " IS NULL");
            }
        }

        return sql.toString();
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj44LogSozaiKanriListCmnVO>selectVO(Tbj44LogSozaiKanriListCmnCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj44LogSozaiKanriListCmnVO());
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
    public void deleteVO(Tbj44LogSozaiKanriListCmnVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.DEL;
        _vo = vo;
        try {
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}