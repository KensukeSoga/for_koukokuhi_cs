package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

/**
*
* <P>
* 契約検索DAO<P>
* <B>修正履歴</B><BR>
* ・新規作成 HAMメンバー<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractSearchDAO extends AbstractRdbDao {

    /**
     * デフォルトコンストラクタ
     */
    public ContractSearchDAO() {
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
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        return getSelectSQLForCntrct();
    }

    /**
     * 契約情報取得SQL
     * @return
     */
    private String getSelectSQLForCntrct() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append("  " + Tbj16ContractInfo.CTRTKBN + " ");
        sql.append(" ," + Tbj16ContractInfo.CTRTNO + " ");
        sql.append(" ," + Mbj12Code.CODENAME + " AS CTRTKBNNAME");
        sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
        sql.append(" ," + Tbj16ContractInfo.DATEFROM + " ");
        sql.append(" ," + Tbj16ContractInfo.DATETO + " ");
        sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
        sql.append(" ,DECODE(" + Tbj16ContractInfo.SALEFLG + ",'Y','あり','--') AS SALES ");
        sql.append(" ," + Tbj16ContractInfo.SALEFLG + " ");
        sql.append(" ," + Tbj16ContractInfo.BIKO + " ");
        sql.append(" ," + Tbj16ContractInfo.HISTORYKEY + " ");
        sql.append(" ," + Tbj16ContractInfo.DCARCD + " ");
        sql.append(" ," + Mbj05Car.CARNM + " ");
        sql.append(" ," + Tbj16ContractInfo.CATEGORY + " ");
        sql.append(" ,DECODE(" + Tbj16ContractInfo.JASRACFLG + ",'Y','あり','--') AS JASRAC ");
        sql.append(" ," + Tbj16ContractInfo.JASRACFLG + " ");
        sql.append(" ," + Tbj16ContractInfo.CRTDATE + " ");
        sql.append(" ," + Tbj16ContractInfo.CRTNM + " ");
        sql.append(" ," + Tbj16ContractInfo.CRTAPL + " ");
        sql.append(" ," + Tbj16ContractInfo.CRTID + " ");
        sql.append(" ," + Tbj16ContractInfo.UPDDATE + " ");
        sql.append(" ," + Tbj16ContractInfo.UPDNM + " ");
        sql.append(" ," + Tbj16ContractInfo.UPDAPL+ " ");
        sql.append(" ," + Tbj16ContractInfo.UPDID + " ");
        sql.append(" FROM ");
        sql.append("  " + Tbj16ContractInfo.TBNAME + " ");
        sql.append("  ," + Mbj05Car.TBNAME + " ");
        sql.append("  ," + Mbj12Code.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj16ContractInfo.DELFLG + " != 'D'");
        sql.append("   AND " + Tbj16ContractInfo.DCARCD + " = " + Mbj05Car.DCARCD + "(+)" );
        sql.append("   AND " + Mbj12Code.CODETYPE + "(+)" + " = '16'" );
        sql.append("   AND " + Tbj16ContractInfo.CTRTKBN + " = " + Mbj12Code.KEYCODE + "(+)" );

        sql.append(" ORDER BY ");
        sql.append("  " + Tbj16ContractInfo.CRTDATE + " ");
        sql.append(" ," + Tbj16ContractInfo.DATETO + " ");

        return sql.toString();
    }

    /**
     * 契約情報のテーブルの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<ContractSearchVO> findContoractListByCondition(ContractSearchCondition cond) throws HAMException {

        super.setModel(new ContractSearchVO());
        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * Modelの生成を行う<br>
     * 検索結果のVOのKEYが大文字のため変換処理を行う<br>
     * AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
     *
     * @param hashList List 検索結果
     * @return List<ContractSearchVO> 変換後の検索結果
     */
    @Override
    protected List createFindedModelInstances(List hashList) {
        List<ContractSearchVO> list = new ArrayList<ContractSearchVO>();
        for (int i = 0; i < hashList.size(); i++) {
            Map result = (Map) hashList.get(i);
            ContractSearchVO vo = new ContractSearchVO();
            vo.setCTRTKBN(StringUtil.trim((String)result.get(Tbj16ContractInfo.CTRTKBN.toUpperCase())));
            vo.setCTRTNO(StringUtil.trim((String)result.get(Tbj16ContractInfo.CTRTNO.toUpperCase())));
            vo.setCTRTKBNNAME(StringUtil.trim((String)result.get("CTRTKBNNAME")));
            vo.setNAMES(StringUtil.trim((String)result.get(Tbj16ContractInfo.NAMES.toUpperCase())));
            vo.setDATEFROM(DateUtil.toDateForNull(result.get(Tbj16ContractInfo.DATEFROM.toUpperCase())));
            vo.setDATETO(DateUtil.toDateForNull(result.get(Tbj16ContractInfo.DATETO.toUpperCase())));
            vo.setMUSIC(StringUtil.trim((String)result.get(Tbj16ContractInfo.MUSIC.toUpperCase())));
            vo.setSALES(StringUtil.trim((String)result.get("SALES")));
            vo.setSALEFLG(StringUtil.trim((String)result.get(Tbj16ContractInfo.SALEFLG.toUpperCase())));
            vo.setBIKO(StringUtil.trim((String)result.get(Tbj16ContractInfo.BIKO.toUpperCase())));
            vo.setHISTORYKEY((BigDecimal)result.get(Tbj16ContractInfo.HISTORYKEY.toUpperCase()));
            vo.setDCARCD(StringUtil.trim((String)result.get(Tbj16ContractInfo.DCARCD.toUpperCase())));
            vo.setCARNM(StringUtil.trim((String)result.get(Mbj05Car.CARNM.toUpperCase())));
            vo.setCATEGORY(StringUtil.trim((String)result.get(Tbj16ContractInfo.CATEGORY.toUpperCase())));
            vo.setJASRAC(StringUtil.trim((String)result.get("JASRAC")));
            vo.setJASRACFLG(StringUtil.trim((String)result.get(Tbj16ContractInfo.JASRACFLG.toUpperCase())));
            vo.setCRTDATE(DateUtil.toDateForNull(result.get(Tbj16ContractInfo.CRTDATE.toUpperCase())));
            vo.setCRTNM(StringUtil.trim((String)result.get(Tbj16ContractInfo.CRTNM.toUpperCase())));
            vo.setCRTAPL(StringUtil.trim((String)result.get(Tbj16ContractInfo.CRTAPL.toUpperCase())));
            vo.setCRTID(StringUtil.trim((String)result.get(Tbj16ContractInfo.CRTID.toUpperCase())));
            vo.setUPDDATE(DateUtil.toDateForNull(result.get(Tbj16ContractInfo.UPDDATE.toUpperCase())));
            vo.setUPDNM(StringUtil.trim((String)result.get(Tbj16ContractInfo.UPDNM.toUpperCase())));
            vo.setUPDAPL(StringUtil.trim((String)result.get(Tbj16ContractInfo.UPDAPL.toUpperCase())));
            vo.setUPDID(StringUtil.trim((String)result.get(Tbj16ContractInfo.UPDID.toUpperCase())));

            //検索結果直後の状態にする
            ModelUtils.copyMemberSearchAfterInstace(vo);
            list.add(vo);

        }

        return list;
    }

}