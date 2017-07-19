package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj45LogSozaiKanriListCmnOAVO;
import jp.co.isid.ham.integ.tbl.Tbj43SozaiKanriListCmnOA;
import jp.co.isid.ham.integ.tbl.Tbj45LogSozaiKanriListCmnOA;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
*
* <P>
* 素材一覧ログ(共有OA期間)DAO<P>
* <B>修正履歴</B><BR>
* ・新規作成(2016/03/10 HDX対応 HLC K.Soga)<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterLogMaterialListCmnOADAO extends AbstractRdbDao {

    /** 更新用VO(Tbj45) */
    private Tbj45LogSozaiKanriListCmnOAVO _vo = null;

    /** EXEC-SQLモード */
    private enum ExcSqlMode {INSLOG};

    /** トランザクションSQLモード変数*/
    private ExcSqlMode _ExcSqlMode = null;

    /** デフォルトコンストラクタ */
    public RegisterLogMaterialListCmnOADAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * EXEC-SQL文を返します
     */
    @Override
    public String getExecString() {
        String sql = "";
        if (_ExcSqlMode.equals(ExcSqlMode.INSLOG)) {
            sql = getExecSQLForInsertLogMaterialListCmnOA();
        }
        return sql;
    }

    /**
     * 素材一覧(共有OA期間)ログを作成するSQLを取得
     * @return
     */
    private String getExecSQLForInsertLogMaterialListCmnOA() {

        Tbj45LogSozaiKanriListCmnOAVO vo = (Tbj45LogSozaiKanriListCmnOAVO)super.getModel();
        StringBuffer sql = new StringBuffer();

        sql.append("INSERT");
        sql.append(" INTO " + Tbj45LogSozaiKanriListCmnOA.TBNAME);
        sql.append(" (");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.DCARCD + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.RECKBN + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.RECNO + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.HISTORYNO + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.HISTORYKBN + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.DELFLG + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.CMCD + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.TEMPCMCD + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.OADATETERM + ",");

        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.CRTDATE + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.CRTNM + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.CRTAPL + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.CRTID + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.UPDDATE + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.UPDNM + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.UPDAPL + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.UPDID);
        sql.append(" )");

        sql.append(" SELECT");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DCARCD + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.SOZAIYM + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.RECKBN + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.RECNO + ",");
        sql.append(" '" + _vo.getHISTORYNO() + "',");
        sql.append(" '" + _vo.getHISTORYKBN() + "',");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DELFLG + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.CMCD + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.OADATETERM + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.CRTDATE + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.CRTNM + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.CRTAPL + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.CRTID + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDDATE + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDNM + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDAPL + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.TBNAME);
        StringBuffer sbWhere = new StringBuffer();

        if (vo.getDCARCD() != null) {
            sbWhere.append(" " + Tbj43SozaiKanriListCmnOA.DCARCD + " = '" + vo.getDCARCD() + "'");
        }
        if (vo.getSOZAIYM() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'YYYY/MM/DD') = '" + DateUtil.toStringGeneral(vo.getSOZAIYM(), "yyyy/MM/dd") + "'");
        }
        if (vo.getRECKBN() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj43SozaiKanriListCmnOA.RECKBN + " = '" + vo.getRECKBN() + "'");
        }
        if (vo.getRECNO() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj43SozaiKanriListCmnOA.RECNO + " = '" + vo.getRECNO() + "'");
        }
        if (vo.getCMCD() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj43SozaiKanriListCmnOA.CMCD + " = '" + vo.getCMCD() + "'");
        }
        if (vo.getTEMPCMCD() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + " = '" + vo.getTEMPCMCD() + "'");
        }
        if (sbWhere.length() > 0) {
            sql.append(" WHERE");
            sql.append(" " + sbWhere.toString());
        }

        return sql.toString();
    }

    /**
     * 素材一覧(共有OA期間)ログテーブルに追加します
     * @param vo
     * @throws HAMException
     */
    public void insertMaterialListCmnOALog(Tbj45LogSozaiKanriListCmnOAVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("登録エラー", "BJ-E0008");

        super.setModel(vo);
        try {
            _ExcSqlMode = ExcSqlMode.INSLOG;
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}