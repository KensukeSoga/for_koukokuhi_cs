package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* ラジオ番組登録画面素材情報検索DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
public class FindRdProgramMaterialDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private FindRdProgramMaterialCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindRdProgramMaterialDAO() {
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
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{ };
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
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return getRdProgramMaterial();
    }

    /**
     * ラジオ番組登録画面素材情報検索SQL文を返します
     *
     * @return String SQL文
     */
    private String getRdProgramMaterial() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" '" + HAMConstants.MATERIAL_KBN_ACTUAL + "' " + FindRdProgramMaterialVO.MATERIALKBN + ",");   //本素材
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj20SozaiKanriList.LIMIT + ",");
        sql.append(" " + Tbj20SozaiKanriList.SYATAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj20SozaiKanriList.FORECOLOR + ",");
        sql.append(" " + Tbj20SozaiKanriList.BACKCOLOR + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' ' AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " BETWEEN TO_DATE('" + _cond.getTermFrom() + "','YYYY/MM/DD') AND TO_DATE('" + _cond.getTermTo() + "', 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NOT NULL AND");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + " IS NOT NULL AND");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN + " = '" + HAMConstants.NOKBN_RADIO + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " = " + Tbj18SozaiKanriData.CMCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

        sql.append(" UNION ALL");

        sql.append(" SELECT");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" '" + HAMConstants.MATERIAL_KBN_TEMP + "',"); //仮素材
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj20SozaiKanriList.LIMIT + ",");
        sql.append(" " + Tbj20SozaiKanriList.SYATAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj20SozaiKanriList.FORECOLOR + ",");
        sql.append(" " + Tbj20SozaiKanriList.BACKCOLOR + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' ' AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " BETWEEN TO_DATE('" + _cond.getTermFrom() + "','YYYY/MM/DD') AND TO_DATE('" + _cond.getTermTo() + "', 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NULL AND");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " IS NOT NULL AND");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + " IS NOT NULL AND");
        sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + " = '" + HAMConstants.NOKBN_RADIO + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " = " + Tbj36TempSozaiKanriData.TEMPCMCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO);

        return sql.toString();
    }

    /**
     * ラジオ番組登録画面素材情報検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindRdProgramMaterialVO> findRdProgramMaterialInfo(FindRdProgramMaterialCondition cond) throws HAMException {

        super.setModel(new FindRdProgramMaterialVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
