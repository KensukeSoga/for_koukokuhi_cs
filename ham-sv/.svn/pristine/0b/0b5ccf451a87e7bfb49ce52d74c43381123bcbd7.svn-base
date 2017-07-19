package jp.co.isid.ham.production.model;

import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

public class DataMoveDAO extends AbstractSimpleRdbDao {

    /**
     * デフォルトコンストラクタ
     */
    public DataMoveDAO() {
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
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        return sql.toString();
    };

//    /**
//     * 画面で指定した条件で検索を行い、一覧に表示するデータを取得します
//     *
//     * @param cond
//     * @return
//     * @throws HAMException
//     */
//    @SuppressWarnings("unchecked")
//    public List<Tbj11CrCreateDataVO> updateForMoveData(FindCrCreateDataCondition cond) throws HAMException {
//        //パラメータチェック
//        if (cond == null) {
//            throw new HAMException("検索エラー", "BJ-E0001");
//        }
//        super.setModel(new Tbj11CrCreateDataVO());
//        try {
////            _SelSqlMode = SelSqlMode.LIST;
//            _moveCrCreateData = cond;
//            return (List<Tbj11CrCreateDataVO>) super.find();
//        } catch (UserException e) {
//            throw new HAMException(e.getMessage(), "BJ-E0001");
//        }
//    }

    ///**
    //* Modelの生成を行う<br>
    //* 検索結果のVOのKEYが大文字のため変換処理を行う<br>
    //* AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
    //*
    //* @param hashList List 検索結果
    //* @return List<CommonCodeMasterVO> 変換後の検索結果
    //*/
    //@Override
    //@SuppressWarnings("unchecked")
    //protected List createFindedModelInstances(List hashList) {
    //List list = null;
    //if (getModel() instanceof MaterialRegisterCntrctVO) {
    //list = new ArrayList<MaterialRegisterCntrctVO>();
    //for (int i = 0; i < hashList.size(); i++) {
    //Map result = (Map) hashList.get(i);
    //MaterialRegisterCntrctVO vo = new MaterialRegisterCntrctVO();
    //vo.setCMCD((String)result.get(Tbj17Content.CMCD.toUpperCase()));
    //vo.setCTRTKBN((String)result.get(Tbj16ContractInfo.CTRTKBN.toUpperCase()));
    //vo.setCTRTNO((String)result.get(Tbj16ContractInfo.CTRTNO.toUpperCase()));
    //vo.setNAMES((String)result.get(Tbj16ContractInfo.NAMES.toUpperCase()));
    //vo.setDATEFROM(DateUtil.toDate((String)result.get(Tbj16ContractInfo.DATEFROM.toUpperCase())));
    //vo.setDATETO(DateUtil.toDate((String)result.get(Tbj16ContractInfo.DATETO.toUpperCase())));
    //vo.setMUSIC((String)result.get(Tbj16ContractInfo.MUSIC.toUpperCase()));
    //vo.setSALEFLG((String)result.get(Tbj16ContractInfo.SALEFLG.toUpperCase()));
    //vo.setCRTDATE(DateUtil.toDate((String)result.get(Tbj16ContractInfo.CRTDATE.toUpperCase())));
    //vo.setUPDDATE(DateUtil.toDate((String)result.get(Tbj16ContractInfo.UPDDATE.toUpperCase())));
    //vo.setUPDNM((String)result.get(Tbj16ContractInfo.UPDNM.toUpperCase()));
    //vo.setUPDAPL((String)result.get(Tbj16ContractInfo.UPDAPL.toUpperCase()));
    //vo.setUPDID((String)result.get(Tbj16ContractInfo.UPDID.toUpperCase()));
    //vo.setDCARCD((String)result.get(Tbj16ContractInfo.DCARCD.toUpperCase()));
    //vo.setCATEGORY((String)result.get(Tbj16ContractInfo.CATEGORY.toUpperCase()));
    //vo.setJASRACFLG((String)result.get(Tbj16ContractInfo.JASRACFLG.toUpperCase()));
    //
    //// 検索結果直後の状態にする
    //ModelUtils.copyMemberSearchAfterInstace(vo);
    //list.add(vo);
    //}
    //}
    //return list;
    //}

    //更新系▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼

    /**
     * Exec()で実行されるデフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {
        StringBuffer sql = new StringBuffer();

        sql.append(" UPDATE ");
        sql.append("     " + Tbj11CrCreateData.TBNAME );
        sql.append(" SET ");
        sql.append("     " + Tbj11CrCreateData.PHASE + "       = " + ConvertToDBString(""));// フェイズ
        sql.append("     " + Tbj11CrCreateData.CRDATE + "      = " + ConvertToDBString(""));// 年月
        sql.append("     " + Tbj11CrCreateData.CLASSDIV + "    = " + ConvertToDBString(""));// データ種別
        sql.append("     " + Tbj11CrCreateData.DCARCD + "      = " + ConvertToDBString(""));// 電通車種コード
        sql.append("     " + Tbj11CrCreateData.SORTNO + "      = " + ConvertToDBString(""));// ソートNo
        sql.append("     " + Tbj11CrCreateData.DIVCD + "       = " + ConvertToDBString(""));// 予算表分類コード
        sql.append("     " + Tbj11CrCreateData.KIKANS + "      = " + ConvertToDBString(""));// 期間From
        sql.append("     " + Tbj11CrCreateData.KIKANE + "      = " + ConvertToDBString(""));// 期間To
        sql.append("     " + Tbj11CrCreateData.SEIKYU + "      = " + ConvertToDBString(""));// 請求先
        sql.append("     " + Tbj11CrCreateData.GETMONEY + "    = " + ConvertToDBString(""));// 取り金額
        sql.append("     " + Tbj11CrCreateData.GETCONF + "     = " + ConvertToDBString(""));// 取り金額確認
        sql.append("     " + Tbj11CrCreateData.PAYMONEY + "    = " + ConvertToDBString(""));// 払い金額
        sql.append("     " + Tbj11CrCreateData.PAYCONF + "     = " + ConvertToDBString(""));// 払い金額確認
        sql.append("     " + Tbj11CrCreateData.ESTMONEY + "    = " + ConvertToDBString(""));// 見積金額
        sql.append("     " + Tbj11CrCreateData.CLMMONEY + "    = " + ConvertToDBString(""));// 請求金額
        sql.append("     " + Tbj11CrCreateData.CLASSCD + "     = " + ConvertToDBString(""));// 予算分類フラグ
        sql.append("     " + Tbj11CrCreateData.KIKANSFLG + "   = " + ConvertToDBString(""));// 期間Fromフラグ
        sql.append("     " + Tbj11CrCreateData.KIKANEFLG + "   = " + ConvertToDBString(""));// 期間Toフラグ
        sql.append("     " + Tbj11CrCreateData.SEIKYUFLG + "   = " + ConvertToDBString(""));// 請求先フラグ
        sql.append("     " + Tbj11CrCreateData.GETMONEYFLG + " = " + ConvertToDBString(""));// 取り金額フラグ
        sql.append("     " + Tbj11CrCreateData.PAYMONEYFLG + " = " + ConvertToDBString(""));// 払い金額フラグ
        sql.append("     " + Tbj11CrCreateData.ESTMONEYFLG + " = " + ConvertToDBString(""));// 見積金額フラグ
        sql.append("     " + Tbj11CrCreateData.CLMMONEYFLG + " = " + ConvertToDBString(""));// 請求金額フラグ
        sql.append("     " + Tbj11CrCreateData.INPUTTNTCD + "  = " + ConvertToDBString(""));// 入力担当
        sql.append("     " + Tbj11CrCreateData.UPDDATE + "     = " + ConvertToDBString(""));// データ更新日時
        sql.append("     " + Tbj11CrCreateData.UPDNM + "       = " + ConvertToDBString(""));// データ更新者
        sql.append("     " + Tbj11CrCreateData.UPDAPL + "      = " + ConvertToDBString(""));// 更新プログラム
        sql.append("     " + Tbj11CrCreateData.UPDID + "       = " + ConvertToDBString(""));// 更新担当者ID
        sql.append(" WHERE ");
        sql.append("     " + Tbj11CrCreateData.DCARCD + "      = " + ConvertToDBString(""));// 電通車種コード
        sql.append(" AND ");
        sql.append("     " + Tbj11CrCreateData.PHASE + "       = " + ConvertToDBString(""));// フェイズ
        sql.append(" AND ");
        sql.append("     " + Tbj11CrCreateData.CRDATE + "      = " + ConvertToDBString(""));// 年月
        sql.append(" AND ");
        sql.append("     " + Tbj11CrCreateData.SEQUENCENO + "  = " + ConvertToDBString(""));// 制作費SEQNO






        return sql.toString();
    }
    //更新系▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

    private String ConvertToDBString(Object obj) {
        return getDBModelInterface().ConvertToDBString(obj);
    }

}
