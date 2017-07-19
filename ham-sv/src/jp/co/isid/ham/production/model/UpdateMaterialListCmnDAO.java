package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnVO;
import jp.co.isid.ham.integ.tbl.Tbj42SozaiKanriListCmn;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
*
* <P>
* 素材一覧(共通)DAO<P>
* <B>修正履歴</B><BR>
* ・新規作成(2016/03/10 HDX対応 HLC K.Soga)<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class UpdateMaterialListCmnDAO extends AbstractRdbDao {

    /** 更新用VO(Tbj42) */
    private Tbj42SozaiKanriListCmnVO _sozaiKanriListCmnVO = null;

    /** 本素材・仮素材フラグ */
    private String _materialType = null;

    /**
     * EXEC-SQLモード
     */
    private enum ExcSqlMode {UPD};

    /**
     * トランザクションSQLモード変数
     */
    private ExcSqlMode _ExcSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public UpdateMaterialListCmnDAO() {
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
        if (_ExcSqlMode.equals(ExcSqlMode.UPD)) {
            sql = getUpdSQLMaterialListCmn();
        }

        return sql;
    }

    /**
     * 素材一覧(共通)更新SQLを作成する
     * @return String 素材一覧(共通)更新SQL
     */
    private String getUpdSQLMaterialListCmn() {

        StringBuffer sql = new StringBuffer();

        sql.append("UPDATE");
        sql.append(" " + Tbj42SozaiKanriListCmn.TBNAME);

        sql.append(" SET");
        sql.append(" " + Tbj42SozaiKanriListCmn.RECNO + " = '" + _sozaiKanriListCmnVO.getRECNO() + "',");
        sql.append(" " + Tbj42SozaiKanriListCmn.DCARCD + " = '" + _sozaiKanriListCmnVO.getDCARCD() + "',");
        sql.append(" " + Tbj42SozaiKanriListCmn.UPDDATE + " = " + getDBModelInterface().getSystemDateString() + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.UPDAPL + " = '" + _sozaiKanriListCmnVO.getUPDAPL() + "',");
        sql.append(" " + Tbj42SozaiKanriListCmn.UPDID + " = '" + _sozaiKanriListCmnVO.getUPDID() + "'");

        sql.append(" WHERE");
        sql.append(" " + Tbj42SozaiKanriListCmn.RECKBN + " = '0'");
        if (_materialType.equals(HAMConstants.MATERIAL_KBN_ACTUAL)) {
            //本素材
            sql.append(" AND " + Tbj42SozaiKanriListCmn.CMCD + " = '" + _sozaiKanriListCmnVO.getCMCD() + "'");
        } else {
            //仮素材
            sql.append(" AND " + Tbj42SozaiKanriListCmn.TEMPCMCD + " = '" + _sozaiKanriListCmnVO.getTEMPCMCD() + "'");
        }
        if (_sozaiKanriListCmnVO.getSOZAIYM() != null) {
            sql.append(" AND " + Tbj42SozaiKanriListCmn.SOZAIYM + " = '" + DateUtil.toStringGeneral(_sozaiKanriListCmnVO.getSOZAIYM(), "yyyy/MM/dd") + "'");
        }

        return sql.toString();
    };

    /**
     * 素材一覧(共通)更新
     * @param vo 更新VO
     * @throws HAMException
     */
    public void updateSQLMaterialListCmn(Tbj42SozaiKanriListCmnVO vo, String materialType) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }

        try {
            _sozaiKanriListCmnVO = vo;
            _materialType = materialType;
            _ExcSqlMode = ExcSqlMode.UPD;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }
}