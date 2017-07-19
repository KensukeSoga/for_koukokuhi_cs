package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu20MsMzBt;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

public class FindMediaByCommonMasterDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindMediaByCommonMasterCondition _condition = null;

    /** SQLモード */
    private enum SqlMode{NAME,CODE };
    private SqlMode _sqlMode = SqlMode.NAME;

    /**
     * デフォルトコンストラクタ
     */
    public FindMediaByCommonMasterDAO() {
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
        return null;
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return null;
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return RepaVbjaMeu20MsMzBt.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu20MsMzBt.SZKBN
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAICD
                ,RepaVbjaMeu20MsMzBt.KBANCD
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ
                ,RepaVbjaMeu20MsMzBt.SINZATSUBTAINMK
                ,RepaVbjaMeu20MsMzBt.BTAISYAKCD
                ,RepaVbjaMeu20MsMzBt.BTAISYASEQNO
                ,RepaVbjaMeu20MsMzBt.KYUTRCD
                ,RepaVbjaMeu20MsMzBt.KHYOYMD
                ,RepaVbjaMeu20MsMzBt.JANR1
                ,RepaVbjaMeu20MsMzBt.JANR2
                ,RepaVbjaMeu20MsMzBt.JANR3
                ,RepaVbjaMeu20MsMzBt.CHUCHIKBN
                ,RepaVbjaMeu20MsMzBt.SINBUNDAIGOCD
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.NAME)) {
            sql=getMediaByMediaNm();
        }
        else if (_sqlMode.equals(SqlMode.CODE)) {
            sql=getMediaByMediaCd();
        }

        return sql;
    }

    /**
     * キーワード検索を行う
     * @return SQL文
     */
    private String getMediaByMediaNm() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        //連番を取得
        sql.append(" ROW_NUMBER() OVER (ORDER BY "+  RepaVbjaMeu20MsMzBt.SZKBN + "," +RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + "," +RepaVbjaMeu20MsMzBt.KBANCD+") AS ROWNO ,");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ + " LIKE('%" + _condition.getSearchNm() + "%')");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SZKBN + " ='" + _condition.getMediaFlg() + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + " ASC, ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.KBANCD + " ASC ");

        return sql.toString();
    }

    /**
     * 媒体コード検索を行う
     * @return SQL文
     */
    private String getMediaByMediaCd() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        //連番を取得
        sql.append(" ROW_NUMBER() OVER (ORDER BY "+  RepaVbjaMeu20MsMzBt.SZKBN + "," +RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + "," +RepaVbjaMeu20MsMzBt.KBANCD+") AS ROWNO ,");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" (" + RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + " || " + RepaVbjaMeu20MsMzBt.KBANCD + ") IN(" + _condition.getMediaCd() +")");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SZKBN + " ='" + _condition.getMediaFlg() + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + " ASC, ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.KBANCD + " ASC ");

        return sql.toString();
    }

    /**
     * キーワードで検索を行う
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindMediaByCommonMasterVO> FindMediaByMediaNm(FindMediaByCommonMasterCondition cond) throws HAMException {

        super.setModel(new FindMediaByCommonMasterVO());

        try {
            _condition = cond;
            _sqlMode = SqlMode.NAME;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 媒体コードで検索を行う
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindMediaByCommonMasterVO> FindMediaByMediaCd(FindMediaByCommonMasterCondition cond) throws HAMException {

        super.setModel(new FindMediaByCommonMasterVO());

        try {
            _condition = cond;
            _sqlMode = SqlMode.CODE;
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
     * @param hashList
     *            List 検索結果
     * @return List<FindMediaByCommonMasterVO> 変換後の検索結果
     */
    @Override
    protected List<FindMediaByCommonMasterVO> createFindedModelInstances(List hashList) {

        List<FindMediaByCommonMasterVO> list = new ArrayList<FindMediaByCommonMasterVO>();

        if (getModel() instanceof FindMediaByCommonMasterVO) {

            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                FindMediaByCommonMasterVO vo = new FindMediaByCommonMasterVO();
                vo.setROWNO((BigDecimal)result.get("ROWNO"));
                vo.setSZKBN((String)result.get(RepaVbjaMeu20MsMzBt.SZKBN.toUpperCase()));
                vo.setSINZATSUBTAICD((String)result.get(RepaVbjaMeu20MsMzBt.SINZATSUBTAICD.toUpperCase()));
                vo.setKBANCD((String)result.get(RepaVbjaMeu20MsMzBt.KBANCD.toUpperCase()));
                vo.setSINZATSUBTAINMJ((String)result.get(RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ.toUpperCase()));
                vo.setSINZATSUBTAINMK((String)result.get(RepaVbjaMeu20MsMzBt.SINZATSUBTAINMK.toUpperCase()));
                vo.setBTAISYAKCD((String)result.get(RepaVbjaMeu20MsMzBt.BTAISYAKCD.toUpperCase()));
                vo.setBTAISYASEQNO((String)result.get(RepaVbjaMeu20MsMzBt.BTAISYASEQNO.toUpperCase()));
                vo.setKYUTRCD((String)result.get(RepaVbjaMeu20MsMzBt.KYUTRCD.toUpperCase()));
                vo.setKHYOYMD((String)result.get(RepaVbjaMeu20MsMzBt.KHYOYMD.toUpperCase()));
                vo.setJANR1((String)result.get(RepaVbjaMeu20MsMzBt.JANR1.toUpperCase()));
                vo.setJANR2((String)result.get(RepaVbjaMeu20MsMzBt.JANR2.toUpperCase()));
                vo.setJANR3((String)result.get(RepaVbjaMeu20MsMzBt.JANR3.toUpperCase()));
                vo.setCHUCHIKBN((String)result.get(RepaVbjaMeu20MsMzBt.CHUCHIKBN.toUpperCase()));
                vo.setSINBUNDAIGOCD((String)result.get(RepaVbjaMeu20MsMzBt.SINBUNDAIGOCD.toUpperCase()));

                // 検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
