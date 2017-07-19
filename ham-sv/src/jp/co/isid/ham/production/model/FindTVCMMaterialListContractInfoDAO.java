package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj40TempSozaiContent;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* TVCM素材一覧契約情報検索DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・HDX対応(2016/03/09 HLC K.Oki)<BR>
* </P>
* @author K.Oki
*/
public class FindTVCMMaterialListContractInfoDAO extends AbstractSimpleRdbDao{

    /** 検索条件 */
    private FindTVCMMaterialListCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindTVCMMaterialListContractInfoDAO() {
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

        return getContractInfo();
    }

    /**
     * TVCM素材一覧契約情報検索SQL文を返します
     * @return String SQL文
     */
    private String getContractInfo(){
        StringBuilder sql = new StringBuilder();

        sql.append("SELECT");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj16ContractInfo.DCARCD + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" " + Tbj16ContractInfo.DELFLG + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj16ContractInfo.DATEFROM + ",");
        sql.append(" " + Tbj16ContractInfo.DATETO + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.JASRACFLG + ",");
        sql.append(" " + Tbj16ContractInfo.SALEFLG + ",");
        sql.append(" " + Tbj16ContractInfo.ENDTITLEFLG + ",");
        sql.append(" " + Tbj16ContractInfo.ARRGORGFLG + ",");
        sql.append(" " + Tbj16ContractInfo.BIKO + ",");
        sql.append(" " + Tbj16ContractInfo.HISTORYKEY + ",");
        sql.append(" " + Tbj16ContractInfo.CRTDATE + ",");
        sql.append(" " + Tbj16ContractInfo.CRTNM + ",");
        sql.append(" " + Tbj16ContractInfo.CRTAPL + ",");
        sql.append(" " + Tbj16ContractInfo.CRTID + ",");
        sql.append(" " + Tbj16ContractInfo.UPDDATE + ",");
        sql.append(" " + Tbj16ContractInfo.UPDNM + ",");
        sql.append(" " + Tbj16ContractInfo.UPDAPL + ",");
        sql.append(" " + Tbj16ContractInfo.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" LEFT OUTER JOIN");
        sql.append(" " + Tbj17Content.TBNAME + " ON " + Tbj17Content.CMCD + " = " + Tbj20SozaiKanriList.CMCD);
        sql.append(" LEFT OUTER JOIN");
        sql.append(" " + Tbj16ContractInfo.TBNAME + " ON " + Tbj16ContractInfo.CTRTKBN + " = " + Tbj17Content.CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + " = " + Tbj17Content.CTRTNO);

        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.OPENFLG + " = '" + HAMConstants.ONE + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' ' AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NOT NULL AND");
        sql.append(" " + Tbj17Content.CTRTKBN + " IS NOT NULL AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + " IS NOT NULL AND");
        sql.append(" " + Tbj16ContractInfo.DELFLG + " = ' ' AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_DATE('" + _cond.getYearMonth() + "', 'YYYYMM')");

        sql.append(" UNION");

        sql.append(" SELECT");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj16ContractInfo.DCARCD + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" " + Tbj16ContractInfo.DELFLG + ",");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj16ContractInfo.DATEFROM + ",");
        sql.append(" " + Tbj16ContractInfo.DATETO + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.JASRACFLG + ",");
        sql.append(" " + Tbj16ContractInfo.SALEFLG + ",");
        sql.append(" " + Tbj16ContractInfo.ENDTITLEFLG + ",");
        sql.append(" " + Tbj16ContractInfo.ARRGORGFLG + ",");
        sql.append(" " + Tbj16ContractInfo.BIKO + ",");
        sql.append(" " + Tbj16ContractInfo.HISTORYKEY + ",");
        sql.append(" " + Tbj16ContractInfo.CRTDATE + ",");
        sql.append(" " + Tbj16ContractInfo.CRTNM + ",");
        sql.append(" " + Tbj16ContractInfo.CRTAPL + ",");
        sql.append(" " + Tbj16ContractInfo.CRTID + ",");
        sql.append(" " + Tbj16ContractInfo.UPDDATE + ",");
        sql.append(" " + Tbj16ContractInfo.UPDNM + ",");
        sql.append(" " + Tbj16ContractInfo.UPDAPL + ",");
        sql.append(" " + Tbj16ContractInfo.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" LEFT OUTER JOIN");
        sql.append(" " +Tbj40TempSozaiContent.TBNAME + " ON " + Tbj40TempSozaiContent.TEMPCMCD + " = " + Tbj20SozaiKanriList.TEMPCMCD);
        sql.append(" LEFT OUTER JOIN");
        sql.append(" " + Tbj16ContractInfo.TBNAME + " ON " + Tbj16ContractInfo.CTRTKBN + " = " + Tbj40TempSozaiContent.CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + " = " + Tbj40TempSozaiContent.CTRTNO);

        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.OPENFLG + " = '" + HAMConstants.ONE + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' ' AND");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " IS NOT NULL AND");
        sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " IS NOT NULL AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + " IS NOT NULL AND");
        sql.append(" " + Tbj16ContractInfo.DELFLG + " = ' ' AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_DATE('" + _cond.getYearMonth() + "', 'YYYYMM')");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj16ContractInfo.DATETO);

        return sql.toString();
    }

    /**
     * TVCM素材一覧契約情報検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindTVCMMaterialListContractInfoVO> findTVCMMaterialListContractInfo(FindTVCMMaterialListCondition cond) throws HAMException {

        super.setModel(new FindTVCMMaterialListContractInfoVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
