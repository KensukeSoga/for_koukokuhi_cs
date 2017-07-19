package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
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
* ラジオ版AllocationPicture素材情報検索DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/11/20 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
public class FindRdAllocationPictureMaterialDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private FindRdAllocationPictureMaterialCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindRdAllocationPictureMaterialDAO() {
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

        return getMaterialInfo();
    }

    /**
     * ラジオ番組素材情報検索SQL文を返します
     * @return String SQL文
     */
    private String getMaterialInfo() {

        StringBuilder sql = new StringBuilder();

        sql.append(" SELECT");
        sql.append(" " + BigDecimal.valueOf(1) + " " + FindRdAllocationPictureMaterialVO.SEQ + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.FORECOLOR + ",");
        sql.append(" " + Tbj20SozaiKanriList.BACKCOLOR);

        sql.append(" FROM");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME + ",");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN + " = '" + HAMConstants.NOKBN_RADIO + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' ' AND");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + " IS NOT NULL AND");
        sql.append(" TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ", 'YYYYMM') = '" + _cond.getYearMonth() + "' AND");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " = " + Tbj20SozaiKanriList.CMCD + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

        sql.append(" UNION ALL");

        sql.append(" SELECT");
        sql.append(" " + BigDecimal.valueOf(2) + ",");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.FORECOLOR + ",");
        sql.append(" " + Tbj20SozaiKanriList.BACKCOLOR);

        sql.append(" FROM");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
        sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + " = '" + HAMConstants.NOKBN_RADIO + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' ' AND");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + " IS NOT NULL AND");
        sql.append(" TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ", 'YYYYMM') = '" + _cond.getYearMonth() + "' AND");
        sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " = " + Tbj20SozaiKanriList.TEMPCMCD + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

        sql.append(" ORDER BY");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE);

        return sql.toString();
    }

    /**
     * ラジオ版AllocationPicture素材情報検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindRdAllocationPictureMaterialVO> findMaterialInfo(FindRdAllocationPictureMaterialCondition cond) throws HAMException {

        super.setModel(new FindRdAllocationPictureMaterialVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
