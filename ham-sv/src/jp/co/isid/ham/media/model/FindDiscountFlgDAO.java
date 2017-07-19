package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu19NbJk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu1ANbNaiyo;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu20MsMzBt;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

public class FindDiscountFlgDAO extends AbstractRdbDao {

    /** 検索条件 */
    private FindDiscountFlgCondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindDiscountFlgDAO() {
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
        return RepaVbjaMeu1ANbNaiyo.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMeu1ANbNaiyo.HMOKCD
                ,RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN1
                ,RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN2
                ,RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN3
                ,RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN4
                ,RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN5
                ,RepaVbjaMeu1ANbNaiyo.NBIKRITU
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        return getDiscountFlg();
    }

    /**
     * 値引き検索のSQL文を返します
     *
     * @return String SQL文
     */
    private String getDiscountFlg() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" '" + _cond.getDaichoNo() + "' AS DAICHONO ,");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + RepaVbjaMeu19NbJk.TBNAME + ", ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu19NbJk.THSKGYCD + " = " + RepaVbjaMeu1ANbNaiyo.THSKGYCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu19NbJk.SEQNO + " = " + RepaVbjaMeu1ANbNaiyo.SEQNO +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu19NbJk.TRTNTSEQNO + " = " + RepaVbjaMeu1ANbNaiyo.TRTNTSEQNO +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu19NbJk.THSKGYCD + " ='" + _cond.getThskgycd() +"' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu19NbJk.SEQNO + " ='" + _cond.getSeqNo() +"' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu19NbJk.TRTNTSEQNO + " ='" + _cond.getTrtntSeqNo() +"' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.GYOMKBN + " ='" + _cond.getWorkFlg() +"' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.BTAICD + " ='" + _cond.getMediaCd()+ _cond.getKbanCd() +"' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.HMOKCD + " ='" + _cond.getItems() +"' ");
        sql.append(" AND ");
        sql.append(" TO_NUMBER(" + RepaVbjaMeu19NbJk.TYSYMD + ") <=" + _cond.getKikanFrom() +" ");
        sql.append(" AND ");
        sql.append(" TO_NUMBER(" + RepaVbjaMeu19NbJk.TYEYMD + ") >=" + _cond.getKikanTo() +" ");
        sql.append(" AND ");
        sql.append(" TO_NUMBER(" + RepaVbjaMeu1ANbNaiyo.TYSYMD + ") <=" + _cond.getKikanFrom() +" ");
        sql.append(" AND ");
        sql.append(" TO_NUMBER(" + RepaVbjaMeu1ANbNaiyo.TYEYMD + ") >=" + _cond.getKikanTo() +" ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.MSCHUOCHIHKBN + " =(");
        sql.append(" SELECT ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.CHUCHIKBN + " ");
        sql.append(" FROM ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.SINZATSUBTAICD + " ='" + _cond.getMediaCd() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu20MsMzBt.KBANCD + " ='" + _cond.getKbanCd() + "' ");
        sql.append(" ) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu1ANbNaiyo.GYOMKBN + " ='" + _cond.getWorkFlg() + "' ");

        return sql.toString();
    }

    /**
     * 値引きの検索を行います
     *
     * @return キャンペーン一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindDiscountFlgVO> findDiscountFlg(FindDiscountFlgCondition cond) throws HAMException {

        super.setModel(new FindDiscountFlgVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * Modelの生成を行う<br>
     * 検索結果のVOのKEYが大文字のため変換処理を行う<br>
     * AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
     *
     * @param hashList
     *            List 検索結果
     * @return List<FindAuthorityAccountBookVO> 変換後の検索結果
     */
    @Override
    protected List<FindDiscountFlgVO> createFindedModelInstances(List hashList) {

        List<FindDiscountFlgVO> list = new ArrayList<FindDiscountFlgVO>();

        if (getModel() instanceof FindDiscountFlgVO) {
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                FindDiscountFlgVO vo = new FindDiscountFlgVO();
                vo.setDAICHONO((String)result.get("DAICHONO"));
                vo.setHMOKCD((String)result.get(RepaVbjaMeu1ANbNaiyo.HMOKCD.toUpperCase()));
                vo.setNBIKNIYOKBN1((String)result.get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN1.toUpperCase()));
                vo.setNBIKNIYOKBN2((String)result.get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN2.toUpperCase()));
                vo.setNBIKNIYOKBN3((String)result.get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN3.toUpperCase()));
                vo.setNBIKNIYOKBN4((String)result.get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN4.toUpperCase()));
                vo.setNBIKNIYOKBN5((String)result.get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN5.toUpperCase()));
                vo.setNBIKRITU((BigDecimal)result.get(RepaVbjaMeu1ANbNaiyo.NBIKRITU.toUpperCase()));

                // 検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
