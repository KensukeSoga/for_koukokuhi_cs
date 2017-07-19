package jp.co.isid.ham.production.model;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj05CarDAO;
import jp.co.isid.ham.common.model.Mbj05CarDAOFactory;
import jp.co.isid.ham.common.model.Mbj05CarVO;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj16ContractInfoCondition;
import jp.co.isid.ham.common.model.Tbj16ContractInfoDAO;
import jp.co.isid.ham.common.model.Tbj16ContractInfoDAOFactory;
import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.common.model.Tbj19JasracCondition;
import jp.co.isid.ham.common.model.Tbj19JasracDAO;
import jp.co.isid.ham.common.model.Tbj19JasracDAOFactory;
import jp.co.isid.ham.common.model.Tbj19JasracVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternCondition;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAOFactory;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.model.base.HAMException;

public class JasracManager
{
    /** 機能種別：制作 */
    private String FUNCTYPE_PRODUCTION = "2";
    /** コード種別：素材 */
    private String CODETYPE_CONTRACTINFO = "16";
    /** 削除フラグ：( ) */
    private String DeleteNo = " ";
    /** 契約種類(楽曲) */
    private String CTRTKBN_MUSIC = "4";
    /** JASRAC登録：あり */
    private String JASRACFLG_YES = "Y";

    /** シングルトンインスタンス */
    private static JasracManager _manager = new JasracManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private JasracManager()
    {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static JasracManager getInstance()
    {
        return _manager;
    }

    /**
     * 排他処理を行う
     * @param cond
     * @return
     * @throws HAMException
     * */
    private boolean checkExclusionForRegisterCreateData(RegistJasracVO vo) throws HAMException
    {
//        if (vo == null)
//        {
//            return false;
//        }
//
//        //排他
//        Tbj19JasracDAO jasracDao = Tbj19JasracDAOFactory.createTbj19JasracDAO();
//        Tbj19JasracCondition cond = new Tbj19JasracCondition();
//        cond.setCtrtkbn(vo.getExclusionCtrtkbnForJasrac());
//
//        List<Tbj19JasracVO> tempVoList = jasracDao.findMaxTimeStamp(cond);
//
//        if ((tempVoList.size() == 0) && (vo.getDataCount() != tempVoList.size()))
//        {
//            return false;
//        }
//
//        if (tempVoList.size() > 0)
//        {
//            if ((tempVoList.get(0).getUPDDATE().compareTo(vo.getMaxDateTimeForJasrac()) > 0) ||
//                (vo.getDataCount() != tempVoList.size()))
//            {
//                return false;
//            }
//        }


        //JASRAC管理の排他チェック
        //==============================================================
        //排他チェック対象のデータを一つのリストにまとめる
        //==============================================================
        List<Tbj19JasracVO> lst = new ArrayList<Tbj19JasracVO>();

        if (vo.getTbj19JASRACUpdateVOListUpd() != null) {
            lst.addAll(vo.getTbj19JASRACUpdateVOListUpd());
        }
        if (vo.getTbj19JASRACDeleteVOListDel() != null) {
            lst.addAll(vo.getTbj19JASRACDeleteVOListDel());
        }

        if (lst != null && lst.size() > 0) {
            //==============================================================
            //排他チェック対象のデータの最新の状態を取得する
            //==============================================================
            Tbj19JasracDAO jasracDao = Tbj19JasracDAOFactory.createTbj19JasracDAO();
            List<Tbj19JasracVO> lockDatas = jasracDao.selectByMultiPk(lst);

            //==============================================================
            //取得した最新データと検索時点の情報を比較して検索時より後に更新されていないかチェック
            //==============================================================
            //取得したデータをMapへ格納しなおす
            Map<String, Date> tempVoMap = new HashMap<String, Date>();
            for (Tbj19JasracVO lockData : lockDatas) {
                tempVoMap.put(getKeyForJasrac(lockData), lockData.getUPDDATE());
            }
            for (Tbj19JasracVO tbj19Jasrac : lst) {
                if (!tempVoMap.containsKey(getKeyForJasrac(tbj19Jasrac))) {
                    //取得したデータの中に更新しようとしているデータがなければ排他エラー
                    return false;
                }
                if (vo.getMaxDateTimeForJasrac().before(tempVoMap.get(getKeyForJasrac(tbj19Jasrac)))) {
                    //更新しようとしているデータの更新日付が検索時点の最大更新日付より後の場合は排他エラー
                    return false;
                }
            }
        }

        return true ;

    }

    /**
     * VOの値からデータを一意に判別するキー値を取得する(JASRAC)
     * @param vo
     * @return
     */
    private String getKeyForJasrac(Tbj19JasracVO vo) {
        return vo.getPHASE() + "|" + vo.getQUOTEKBN() + "|" + vo.getSEIKYUYM() + "|" + vo.getCTRTKBN() + "|" + vo.getCTRTNO();
    }

    /**
     * JASRAC登録画面初期表示時取得テーブルリストを検索します
     *
     * @return ContractRegisterResult 汎用マスタ検索データ
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public FindJasracResult findJasrac(FindJasracCondition cond) throws HAMException
    {
        //検索結果
        FindJasracResult result = new FindJasracResult();

        //権限取得
        //******************************************************
        //機能制御Infoの取得
        //******************************************************
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormid());
        funccond.setFunctype(FUNCTYPE_PRODUCTION);
        funccond.setHamid(cond.getHamid());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        //******************************************************
        //セキュリティ情報取得
        //******************************************************
        SecurityInfoManager secManager = SecurityInfoManager.getInstance();
        SecurityInfoCondition secCond = new SecurityInfoCondition();
        List<SecurityInfoVO> secVolist = new ArrayList<SecurityInfoVO>();
        secCond.setHamid(cond.getHamid());
        secCond.setKksikognzuntcd(cond.getKksikognzuntcd());
        secCond.setSecuritycd("S000000105");
        secCond.setUsertype(cond.getUsertype());
        secVolist = secManager.getSecurityInfo(secCond).getSecurityInfo();
        result.setSecurityInfoVoList(secVolist);

        //コードマスタの取得
        Mbj12CodeCondition codeCondition = new Mbj12CodeCondition();
        codeCondition.setCodetype(CODETYPE_CONTRACTINFO);// CodeType設定
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        List<Mbj12CodeVO> mbj12CodeVOlist = codeDao.selectVO(codeCondition);
        result.setMbj12CodeVOList(mbj12CodeVOlist);

        //車種マスタの取得
        Mbj05CarCondition carCondition = new Mbj05CarCondition();
        Mbj05CarDAO carDao = Mbj05CarDAOFactory.createMbj05CarDAO();
        List<Mbj05CarVO> mbj05CarVOlist = carDao.selectVO(carCondition);
        result.setMbj05CarVOList(mbj05CarVOlist);

        //契約情報テーブルの取得
        Tbj16ContractInfoDAO contractInfoDao = Tbj16ContractInfoDAOFactory.createTbj16ContractInfoDAO();
        Tbj16ContractInfoCondition contractInfoCond = new Tbj16ContractInfoCondition();
        contractInfoCond.setDelflg(DeleteNo);     //削除されていないデータを取得
        contractInfoCond.setCtrtkbn(CTRTKBN_MUSIC);    //楽曲のみを取得
        contractInfoCond.setJasracflg(JASRACFLG_YES);  //JASRAC登録フラグ"Y",JASRAC登録ありのデータだけ取得
        List<Tbj16ContractInfoVO> tbj16ContractInfoVOlist = contractInfoDao.selectVO(contractInfoCond);
        result.setTbj16ContractInfoVOList(tbj16ContractInfoVOlist);

        //JASRAC登録テーブルの取得
        Tbj19JasracDAO JasracDao = Tbj19JasracDAOFactory.createTbj19JasracDAO();
        Tbj19JasracCondition jasracCond = new Tbj19JasracCondition();
        List<Tbj19JasracVO> tbj19JasracVOList = JasracDao.selectVO(jasracCond);
        result.setTbj19JasracVOList(tbj19JasracVOList);

        //一覧表示パターン取得
        Tbj30DisplayPatternDAO patternDao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition displayPatternCond = new Tbj30DisplayPatternCondition();
        displayPatternCond.setHamid(cond.getHamid());
        displayPatternCond.setFormid(cond.getFormid());
        List<Tbj30DisplayPatternVO> displayPatternVoList = patternDao.selectVO(displayPatternCond);
        result.setTbj30DisplayPatternVoList(displayPatternVoList);

        //画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO displayControlDao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition displayControlCond = new Mbj37DisplayControlCondition();
        displayControlCond.setFormid(cond.getFormid());
        List<Mbj37DisplayControlVO> displayControlVoList = displayControlDao.selectVO(displayControlCond);
        result.setMbj37DisplayControlVoList(displayControlVoList);

        return result;
    }

    /**
     * JASRAC情報を登録する
     * @param cond
     * @return
     * @throws HAMException
     */
    public RegistJasracResult registJasrac(RegistJasracVO vo) throws HAMException
    {
        RegistJasracResult result = new RegistJasracResult();

        if (vo == null)
        {
            return null;
        }

        if (!checkExclusionForRegisterCreateData(vo))
        {
            throw new HAMException("排他チェックエラー", "BJ-E0005");
        }

        Tbj19JasracDAO dao = Tbj19JasracDAOFactory.createTbj19JasracDAO();

        for (int i = 0 ; (vo.getTbj19JASRACDeleteVOListDel() != null) && (i < vo.getTbj19JASRACDeleteVOListDel().size()) ; i++)
        {
            //四半期区分が変わる可能性があるので、Delete Insertを行う(更新処理).
            dao.deleteVO(vo.getTbj19JASRACDeleteVOListDel().get(i));
        }
        for (int i = 0 ; (vo.getTbj19JASRACInsertVOListReg() != null) && (i < vo.getTbj19JASRACInsertVOListReg().size()) ; i++)
        {
            //新規、更新データをInsertする(更新データもTbj19JASRACInsertVOListRegへ入っている).
            dao.insertVO(vo.getTbj19JASRACInsertVOListReg().get(i));
        }

        return result ;

    }

}
