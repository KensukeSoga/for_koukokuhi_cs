package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
/**
 * <P>
 * 制作請求表出力データ存在チェック（請求のチェック）
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/3 J.Kamiyama)<BR>
 * ・請求業務変更不具合対応(2016/03/02 HLC K.Oki)<BR>
 * </P>
 * @author J.Kamiyama
 */
public class CheckBillProductionOutputSeikyuDAO extends AbstractRdbDao {

    private CheckBillProductionOutputCondition _condition = null;

    /* 2016/03/02 HDX対応 HLC K.Oki ADD Start */
    /** コンボ(すべてのItemData値) */
    private static final String ALL_ITEM_DATA = "-1";
    /* 2016/03/02 HDX対応 HLC K.Oki ADD End */

    /**
     * デフォルトコンストラクタ
     */
    public CheckBillProductionOutputSeikyuDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
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
        return new String[]{
                Tbj22SeisakuhiSs.DCARCD,
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return Tbj22SeisakuhiSs.TBNAME;
    }

    /**
     * 更新日付フィールドを取得する
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
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(", ");
            }
        }
        sql.append(" FROM ");
        sql.append(Tbj22SeisakuhiSs.TBNAME);
        sql.append(" , ");
        sql.append(Tbj06EstimateDetail.TBNAME);
        sql.append(" , ");
        sql.append(Tbj07EstimateCreate.TBNAME);
        sql.append(" WHERE ");
        sql.append(Tbj22SeisakuhiSs.CLASSDIV);
        sql.append(" = '0'");
        sql.append(" AND ");

        //請求先Grが「すべて」以外の場合の編集(-1が「すべて」)
        /* 2016/03/02 HDX対応 HLC K.Oki MOD Start */
        //if (_condition.getDemandGroup().equals("-1")) {
        if (!(_condition.getDemandGroup().equals(ALL_ITEM_DATA))) {
        /* 2016/03/02 HDX対応 HLC K.Oki MOD End */
            sql.append("( ");
            sql.append(Tbj22SeisakuhiSs.GROUPCD);
            sql.append(" = ");
            sql.append(_condition.getDemandGroup());
            sql.append(" OR ");
            sql.append(Tbj22SeisakuhiSs.GROUPCD);
            sql.append(" is null ) ");
            sql.append(" AND ");
        }

        sql.append(Tbj22SeisakuhiSs.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" >= TO_DATE('");
        sql.append(_condition.getYearMonthFrom());
        sql.append("', 'YYYY/MM')");
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" <= TO_DATE('");
        sql.append(_condition.getYearMonthTo());
        sql.append("', 'YYYY/MM')");
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.ESTDETAILSEQNO);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.ESTDETAILSEQNO);
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.DCARCD);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.DCARCD);
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.PHASE);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.PHASE);
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.CRDATE);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.CRDATE);
        sql.append(" AND ");
        sql.append(Tbj22SeisakuhiSs.SEQUENCENO);
        sql.append(" = ");
        sql.append(Tbj07EstimateCreate.SEQUENCENO);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public void selectVO(CheckBillProductionOutputCondition condition) throws HAMException {

        List<CheckBillProductionVO> result = null;

        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        if (condition.getPhase() == 0) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        if (condition.getYearMonthFrom() == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        if (condition.getYearMonthTo() == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        if (condition.getDemandGroup() == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new CheckBillProductionOutputVO());
        try {
            _condition = condition;
            result = super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }

        if (result.size() == 0) {
            throw new HAMException("存在エラー","BJ-W0245");
        }
    }

}
