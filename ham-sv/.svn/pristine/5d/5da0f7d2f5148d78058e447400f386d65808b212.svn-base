package jp.co.isid.ham.login.model;

import java.io.StringReader;
import java.util.List;
import java.util.Map;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdVO;
import jp.co.isid.ham.common.model.Tbj35KnrCondition;
import jp.co.isid.ham.common.model.Tbj35KnrDAO;
import jp.co.isid.ham.common.model.Tbj35KnrDAOFactory;
import jp.co.isid.ham.common.model.Tbj35KnrVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.security.SecurityInfo;
import jp.co.isid.nj.security.impl.base.BaseUserInfo;
import jp.co.isid.njsecurity.webservice.stateless.GetSecurityRoleListParameter;
import jp.co.isid.njsecurity.webservice.stateless.GetSecurityRoleListResult;
import jp.co.isid.njsecurity.webservice.stateless.LoginParameter;
import jp.co.isid.njsecurity.webservice.stateless.LoginResult;
import jp.co.isid.njsecurity.webservice.stateless.NJSecurityStatelessService;
import jp.co.isid.njsecurity.webservice.stateless.SecurityInfoUtil;

import org.w3c.dom.CharacterData;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;

/**
 * <P>
 * 業務会計セキュリティロール取得Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/05/17 JSE K.Tamura)<BR>
 * </P>
 *
 * @author JSE K.Tamura
 */
public class MprKengenCheckManager {

    /** カテゴリー：相対権限 */
    private static final String CATEGORY_RELATIVE_AUTHORITY = "201";

    /** シングルトンインスタンス */
    private static MprKengenCheckManager _manager = new MprKengenCheckManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private MprKengenCheckManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static MprKengenCheckManager getInstance() {
        return _manager;
    }

    /**
     * 業務会計セキュリティロール（相対権限）の取得
     *
     * @param cond 検索条件
     * @return 業務会計セキュリティロール（相対権限）
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public String getAccountSecurityRole(AccountSecurityRoleCondition cond) throws HAMException {

        // ログイン時の端末情報を取得
        SecurityInfo securityInfo = SecurityInfoUtil.deserialize(cond.getSecurityInfo());
        BaseUserInfo userInfo = (BaseUserInfo) securityInfo.getUserInfo();
        Map loginItemMap = userInfo.getLoginItems();

        // 業務会計のディレクトリ情報取得
        LoginParameter loginParameter = new LoginParameter();
        loginParameter.setAppId(cond.getAplId());
        loginParameter.setBrowser((String) loginItemMap.get("Browser"));
        loginParameter.setId(cond.getEsqId());
        loginParameter.setIpAddress((String) loginItemMap.get("IPAddr"));
        loginParameter.setOs((String) loginItemMap.get("OS"));
        loginParameter.setPass(cond.getPassword());
        loginParameter.setTerminalKind((String) loginItemMap.get("TerminalKind"));

        // 業務会計のディレクトリ情報取得
        NJSecurityStatelessService service = new NJSecurityStatelessService();
        LoginResult loginResult = service.login(loginParameter);

        // 業務会計のロール情報取得
        GetSecurityRoleListParameter securityRoleListParameter = new GetSecurityRoleListParameter();
        securityRoleListParameter.setCategory(CATEGORY_RELATIVE_AUTHORITY);
        securityRoleListParameter.setSecurityInfo(loginResult.getSecurityInfo());
        GetSecurityRoleListResult securityRoleListResult = service.getSecurityRoleList(securityRoleListParameter);

        // 業務会計セキュリティロール（相対権限）を返却
        return getRelativeAuthority(securityRoleListResult.getResultXml());

    }

    /**
     * 相対権限の取得
     *
     * @param xmlRecords XML情報
     * @return 相対権限
     * @throws HAMException 処理中にエラーが発生した場合
     */
    private String getRelativeAuthority(String xmlRecords) throws HAMException {

        String relativeAuthority = null;

        try {
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            DocumentBuilder db = dbf.newDocumentBuilder();
            InputSource is = new InputSource();
            is.setCharacterStream(new StringReader(xmlRecords));

            Document doc = db.parse(is);
            NodeList firstNode = doc.getElementsByTagName("SecurityRoleList");
            Element firstNodeElement = (Element) firstNode.item(0);
            NodeList secondNode = firstNodeElement.getElementsByTagName("SecurityRole");
            Element secondNodeElement = (Element) secondNode.item(0);
            NodeList name = secondNodeElement.getElementsByTagName("RoleData");
            Element line = (Element) name.item(0);
            relativeAuthority = getCharacterDataFromElement(line);

            return relativeAuthority;

            // return "31";
        } catch (Exception e) {
            // throw new HAMException("セキュリティデータ取得エラー", "HF-W0001");
            // 新聞局ユーザーの対応のため、nullを返すように変更
            return null;
        }

    }

    /**
     * 対象要素取得
     *
     * @param xmlRecords XML情報
     * @return 相対権限
     * @throws HAMException 処理中にエラーが発生した場合
     */
    private static String getCharacterDataFromElement(Element e) throws HAMException {

        Node child = e.getFirstChild();
        if (child instanceof CharacterData) {
            CharacterData cd = (CharacterData) child;
            return StringUtil.trim(cd.getData());
        }
        else {
            throw new HAMException("セキュリティデータ取得エラー", "HF-W0001");
        }
    }

    // /**
    // * 管理者ユーザー情報の取得
    // *
    // * @param cond 検索条件
    // * @return 管理者ユーザー情報
    // * @throws HAMException 処理中にエラーが発生した場合
    // */
    // public Mhf31TntVO findKanriUserInfo(AccountSecurityRoleCondition cond) throws HAMException {
    //
    // KanriUserInfoDAO dao = KanriUserInfoDAOFactory.createKanriUserInfoDAO();
    //
    // List<Mhf31TntVO> list = dao.getKanriUserInfo(cond);
    //
    // // データが0件の場合
    // if (list.size() == 0) {
    // return null;
    // }
    //
    // return list.get(0);
    //
    // }

    // ==========================================================================================================================
    // ==========================================================================================================================
    // ==========================================================================================================================
    // ==========================================================================================================================
    // ==========================================================================================================================
    // ==========================================================================================================================

    /** 相対権限：部権限 */
    private static final String RELATIVE_AUTHORITY_BU = "7";

    /** 相対権限：局権限 */
    private static final String RELATIVE_AUTHORITY_KYOKU = "31";

    /** 階層コード：局所属 */
    private static final String KAISO_CD_KYOKUSHOZOKU = "40";

    /** 階層コード：部所属 */
    private static final String KAISO_CD_BUSHOZOKU = "60";

    /** 信用コード：対象外 */
    private static final String[] SINCD_NOT_SUBJECT = { "7", "8", "9", "A", "X" };

    public MprKengenCheckResult execute(MprKengenCheckCondition cond) throws HAMException {

        MprKengenCheckResult result = new MprKengenCheckResult();

        // 営業日
        String eigyobi = "";
        // AM局局コード
        String kyokuCd = "";
        // 営業所コード
        String egsCd = "";
        // 得意先企業コード
        String thsKgyCd = "";
        // 得意先部門SEQ
        String thsBmnSeq = "";
        // 相対権限
        String relativeAuthority = "";
        // 運用No
        String operationCd = "";
        // 担当者コード
        String tantoCd = "";

        // パラメータから移送
        eigyobi = cond.getEigyobi();
        operationCd = cond.getOperationNo();
        tantoCd = cond.getTantoCd();

        // ***********************************
        // 相対権限取得
        // ***********************************
        AccountSecurityRoleCondition accountSecRoleCond = new AccountSecurityRoleCondition();
        accountSecRoleCond.setAplId(cond.getAplId());
        accountSecRoleCond.setEsqId(cond.getEsqId());
        accountSecRoleCond.setPassword(cond.getPassword());
        accountSecRoleCond.setSecurityInfo(cond.getSecurityInfo());
        relativeAuthority = getAccountSecurityRole(accountSecRoleCond);

        // ***********************************
        // 営業所コード取得
        // ***********************************
        RepaVbjaMeu07SikKrSprdDAO sikKrSprdDao = RepaVbjaMeu07SikKrSprdDAOFactory.createRepaVbjaMeu07SikKrSprdDAO();
        RepaVbjaMeu07SikKrSprdVO sikKrSprdCond = new RepaVbjaMeu07SikKrSprdVO();
        sikKrSprdCond.setSIKCD(operationCd);
        sikKrSprdCond.setSTARTYMD(eigyobi);
        sikKrSprdCond.setENDYMD(eigyobi);
        List<RepaVbjaMeu07SikKrSprdVO> sikKrSprdVoList = sikKrSprdDao.selectVoByDate(sikKrSprdCond);
        if (sikKrSprdVoList.size() > 0) {
            egsCd = sikKrSprdVoList.get(0).getEGSYOCD();
        }

        if (StringUtil.isBlank(relativeAuthority)) {
            //ロールの取得ができなければその時点でNG
            result.setRelativeAuthority(relativeAuthority);
            result.setEgsCd(egsCd);
            result.setCheckResult(false);
            return result;
        }

        // ***********************************
        // システム管理情報取得(営業日取得)
        // ***********************************
        Tbj35KnrDAO knrDao = Tbj35KnrDAOFactory.createTbj35KnrDAO();
        Tbj35KnrCondition knrCond = new Tbj35KnrCondition();
        knrCond.setSystemno("02");
        List<Tbj35KnrVO> knrVoList = knrDao.selectVO(knrCond);

        if (knrVoList.size() != 1) {
            //throw new HAMException("システム管理情報取得エラー", "BJ-E0003");
            result.setRelativeAuthority(relativeAuthority);
            result.setEgsCd(egsCd);
            result.setCheckResult(false);
            return result;
        }
        eigyobi = knrVoList.get(0).getEIGYOBI();

        // ***********************************
        // ログイン局が判定対象の局かを判定
        // ***********************************
        // コードマスタ情報取得(局コード)
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype("04");
        codeCond.setKeycode("KYOKUCODE");
        List<Mbj12CodeVO> codeVoList = codeDao.selectVO(codeCond);
        if (codeVoList.size() > 0) {
            kyokuCd = codeVoList.get(0).getCODENAME();
        }
        if (!kyokuCd.equals(cond.getKyokuCd())) {
            result.setRelativeAuthority(relativeAuthority);
            result.setEgsCd(egsCd);
            result.setCheckResult(true);
            return result;
        }

        // ***********************************
        // 担当者の所属組織と得意先コードで得意先担当マスタを検索して担当チェックを行う
        // ***********************************
        // 企業コード取得
        codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype("04");
        codeCond.setKeycode("HONDA");
        codeVoList = codeDao.selectVO(codeCond);
        if (codeVoList.size() > 0) {
            thsKgyCd = codeVoList.get(0).getCODENAME();
        }
        // SEQNO取得
        codeCond.setCodetype("04");
        codeCond.setKeycode("SEQNO");
        codeVoList = codeDao.selectVO(codeCond);
        if (codeVoList.size() > 0) {
            thsBmnSeq = codeVoList.get(0).getCODENAME();
        }

        // ***********************************
        // 担当者チェック
        // ***********************************
        // 職位グループを取得
        String sGrpCd = getSyokuiGrpCd(cond.getEsqId(), eigyobi);

        // 組織・階層情報の取得
        EigyosyoInfoVO sikKaisoVO = getSikKaisoInfoVO(operationCd, eigyobi);// TODO:運用No
        if (sikKaisoVO == null) {
            result.setRelativeAuthority(relativeAuthority);
            result.setEgsCd(egsCd);
            result.setCheckResult(false);
            return result;
        }

        // 得意先情報取得
        TksInfoCondition tksCond = new TksInfoCondition();
        // tksCond.setEigyobi(eigyobi);
        // tksCond.setEgsCd(egsCd);
        // tksCond.setSikInfo(sikInfo.getSoshikiInfo());
        // tksCond.setSikCond(sikInfo.getSqlConditionOfSoshiki());
        // tksCond.setKokaiTokuisakiInfo(kTI_list);
        tksCond.setTksKgyCd(thsKgyCd);
        tksCond.setTksBmnSeqNo(thsBmnSeq);
        tksCond.setSikcd(operationCd);
        tksCond.setEgsCd(egsCd);
        tksCond.setEigyobi(eigyobi);
        TksInfoVO tksVo = getTksInfo(tksCond);
        if (tksVo == null) {
            result.setRelativeAuthority(relativeAuthority);
            result.setEgsCd(egsCd);
            result.setCheckResult(false);
            return result;
        }

        // チェック用組織コード
        String organizaitonCodeForCheck = null;

        // 局権限の場合
        if (RELATIVE_AUTHORITY_KYOKU.equals(relativeAuthority)) {

            // 部所属の場合
            if (KAISO_CD_BUSHOZOKU.equals(sikKaisoVO.getKaisoCd())) {

                // 上位組織情報（局）の取得
                sikKrSprdCond = new RepaVbjaMeu07SikKrSprdVO();
                sikKrSprdCond.setKRIJSIKCD(sikKaisoVO.getJSikCd());
                sikKrSprdCond.setEGSYOCD(egsCd);
                sikKrSprdCond.setSTARTYMD(eigyobi);
                sikKrSprdCond.setENDYMD(eigyobi);
                RepaVbjaMeu07SikKrSprdVO jSikInfo = getJSoshikiInfo(sikKrSprdCond);
                if (jSikInfo == null) {
                    result.setRelativeAuthority(relativeAuthority);
                    result.setEgsCd(egsCd);
                    result.setCheckResult(false);
                    return result;
                }

                // チェック用組織コードに上位組織コード（局）を設定
                organizaitonCodeForCheck = jSikInfo.getSIKCDKYK();

                // 得意先情報の局表示名（漢字）を、上位組織情報（局）のものに上書き
                // for (int i = 0; i< tks_list.size(); i++) {
                // tks_list.get(i).setKykHyojiKj(jSikInfo.getKykHyojiKj());
                // ModelUtils.copyMemberSearchAfterInstace(tks_list.get(i));
                // }
            }
            // 局所属の場合
            else if (KAISO_CD_KYOKUSHOZOKU.equals(sikKaisoVO.getKaisoCd())) {

                // チェック用組織コードに運用No.を設定
                organizaitonCodeForCheck = operationCd;
            }
        }
        // 部権限の場合
        else if (RELATIVE_AUTHORITY_BU.equals(relativeAuthority)) {
            // チェック用組織コードに運用No.を設定
            organizaitonCodeForCheck = operationCd;
        }

        // 公開範囲／ユニットNo.マスタ情報格納変数
        KhUnMstVO kUnitMstVO;
        // ループの度にnullを代入し、初期化する
        kUnitMstVO = null;

        boolean chkres = false;
        // 部権限の場合
        if (RELATIVE_AUTHORITY_BU.equals(relativeAuthority)) {

            // 担当者組織チェック（部）
            if (organizaitonCodeForCheck.equals(tksVo.getSIKCDBU())) {

                // 信用コードチェック
                if (checkSinCd(tksVo.getSINCD())) {
                    chkres = true;
                }
                else {
                    chkres = false;
                }
            } else {
                // 公開範囲／ユニットNo.マスタ情報取得
                KhUnMstCondition kkhCond = new KhUnMstCondition();
                kkhCond.setJSikCd(sikKaisoVO.getJSikCd());// 上位組織コード
                kkhCond.setOperationNo(operationCd);// 所属組織コードは運用No.
                kkhCond.setSyokuiGrpCd(sGrpCd);// 職位等級グループ
                kkhCond.setTntCd("'" + tantoCd + "', '*'");
                kkhCond.setEigyobi(eigyobi);

                kkhCond.setTksCd(tksVo.getTHSKGYCD() + tksVo.getSEQNO() + tksVo.getTRTNTSEQNO());// 得意先コード（10桁）
                kkhCond.setTermBegin(DateUtil.getTermBegin(eigyobi));
                kkhCond.setTermEnd(DateUtil.getTermEnd(eigyobi));
                // kUnitMstVO = getKhUnMstInfo(sikKaisoVO, sGI_result, tks_list.get(i));
                kUnitMstVO = getKhUnMstInfo(kkhCond);
                if (kUnitMstVO == null) {
                    chkres = false;
                }
                else {
                    // 信用コードチェック
                    if (checkSinCd(tksVo.getSINCD())) {
                        chkres = true;
                    }
                    else {
                        chkres = false;
                    }
                }
            }
        }
        // 局権限の場合
        else if (RELATIVE_AUTHORITY_KYOKU.equals(relativeAuthority)) {

            // 担当者組織チェック（局）
            if (organizaitonCodeForCheck.equals(tksVo.getSIKCDKYK())) {

                // 信用コードチェック
                if (checkSinCd(tksVo.getSINCD())) {
                    // // 得意先情報から得意先リストを設定
                    // setTksListForTksInfo(tksVo);
                    chkres = true;
                } else {
                    // _errorInfo = setErrorInfo("信用コードチェックエラー", "HF-W0012");
                    chkres = false;
                }
            } else {
                // 公開範囲／ユニットNo.マスタ情報取得
                KhUnMstCondition kkhCond = new KhUnMstCondition();
                kkhCond.setJSikCd(sikKaisoVO.getJSikCd());// 上位組織コード
                kkhCond.setOperationNo(operationCd);// 所属組織コードは運用No.
                kkhCond.setSyokuiGrpCd(sGrpCd);// 職位等級グループ
                kkhCond.setTntCd("'" + tantoCd + "', '*'");
                kkhCond.setEigyobi(eigyobi);

                kkhCond.setTksCd(tksVo.getTHSKGYCD() + tksVo.getSEQNO() + tksVo.getTRTNTSEQNO());// 得意先コード（10桁）
                kkhCond.setTermBegin(DateUtil.getTermBegin(eigyobi));
                kkhCond.setTermEnd(DateUtil.getTermEnd(eigyobi));
                // kUnitMstVO = getKhUnMstInfo(sikKaisoVO, sGI_result, tks_list.get(i));
                kUnitMstVO = getKhUnMstInfo(kkhCond);
                if (kUnitMstVO == null) {
                    chkres = false;
                }
                else {
                    // 信用コードチェック
                    if (checkSinCd(tksVo.getSINCD())) {
                        chkres = true;
                    }
                    else {
                        chkres = false;
                    }
                }
            }

        } else if (relativeAuthority == null || relativeAuthority.trim().length() == 0) {

            chkres = false;

        } else {
            // その他の権限の場合

            // 公開範囲／ユニットNo.マスタ情報取得
            KhUnMstCondition kkhCond = new KhUnMstCondition();
            kkhCond.setJSikCd(sikKaisoVO.getJSikCd());// 上位組織コード
            kkhCond.setOperationNo(operationCd);// 所属組織コードは運用No.
            kkhCond.setSyokuiGrpCd(sGrpCd);// 職位等級グループ
            kkhCond.setTntCd("'" + tantoCd + "', '*'");
            kkhCond.setEigyobi(eigyobi);

            kkhCond.setTksCd(tksVo.getTHSKGYCD() + tksVo.getSEQNO() + tksVo.getTRTNTSEQNO());// 得意先コード（10桁）
            kkhCond.setTermBegin(DateUtil.getTermBegin(eigyobi));
            kkhCond.setTermEnd(DateUtil.getTermEnd(eigyobi));
            kUnitMstVO = getKhUnMstInfo(kkhCond);
            if (kUnitMstVO == null) {
                chkres = false;
            }
            else {
                // 信用コードチェック
                if (checkSinCd(tksVo.getSINCD())) {
                    chkres = true;
                }
                else {
                    chkres = false;
                }
            }
        }

        // // 公開範囲／ユニットNo.マスタ情報データなし
        // if (kUnitMstVO == null) {
        // chkres = false;
        // }
        // // 信用コードチェック
        // if (checkSinCd(tksVo.getSINCD())) {
        // chkres = true;
        // }
        // else {
        // chkres = false;
        // }

        result.setRelativeAuthority(relativeAuthority);
        result.setEgsCd(egsCd);
        result.setCheckResult(chkres);
        return result;
    }

    /**
     * 職位等級グループコードの取得処理を実行します
     *
     * @return 職位等級グループコード
     * @throws CNPException 検索に失敗した場合
     */
    public String getSyokuiGrpCd(String esqId, String eigyobi) throws HAMException {
        MprKengenCheckDAO dao = MprKengenCheckDAOFactory.createMPRKengenChkDAO();
        SyokuiGrpInfoCondition cond = new SyokuiGrpInfoCondition();
        cond.setEsqId(esqId);
        cond.setEigyobi(eigyobi);
        List<SyokuiGrpInfoVO> voList = dao.getSyokuiGrpInfo(cond);

        String groupJonCd;
        if (voList.size() == 0) {
            // 社外者の場合、職位等級コードなし
            groupJonCd = "'*'";
        }
        else {
            StringBuffer grpCd = new StringBuffer();
            for (int i = 0; i < voList.size(); i++) {
                grpCd.append("'" + voList.get(i).getGrpCd() + "',");
            }
            grpCd.append("'*'");
            groupJonCd = grpCd.toString();
        }
        return groupJonCd;
    }

    /**
     * 検索条件を使用し、組織階層情報の取得処理を実行します
     *
     * @return 組織階層情報VO
     * @throws CNPException 検索に失敗した場合
     */
    public EigyosyoInfoVO getSikKaisoInfoVO(String tntSikCd, String eigyobi) throws HAMException {
        MprKengenCheckDAO dao = MprKengenCheckDAOFactory.createMPRKengenChkDAO();
        EigyosyoInfoCondition cond = new EigyosyoInfoCondition();
        cond.setTntSikCd(tntSikCd);// 担当者組織コードは運用No.
        cond.setEigyobi(eigyobi);
        List<EigyosyoInfoVO> voList = dao.getEigyosyoInfo(cond);

        // データが0件の場合
        if (voList.size() == 0) {
            //throw new HAMException("組織階層情報取得エラー", "HF-W0010");
            return null;
        }
        return voList.get(0);
    }

    /**
     * 組織情報と公開得意先情報を使用し、得意先情報（得意先リスト表示用）取得処理を実行します
     *
     * @param sikInfo 組織情報
     * @param kTI_List 公開得意先情報
     * @return 得意先情報（得意先リスト表示用）VOリスト
     * @throws CNPException 検索に失敗した場合
     */
    public TksInfoVO getTksInfo(TksInfoCondition cond) throws HAMException {
        MprKengenCheckDAO dao = MprKengenCheckDAOFactory.createMPRKengenChkDAO();
        List<TksInfoVO> voList = dao.getTksInfo(cond);

        // データが0件の場合
        if (voList.size() == 0) {
            //throw new HAMException("得意先情報取得", "HF-W0009");
            return null;
        }
        return voList.get(0);
    }

    /**
     * 検索条件を使用し、上位組織コード(局)の取得処理を実行します
     *
     * @return 上位組織コード(局)
     * @param 組織階層情報
     * @param 個人情報
     * @throws CNPException 検索に失敗した場合
     */
    public RepaVbjaMeu07SikKrSprdVO getJSoshikiInfo(RepaVbjaMeu07SikKrSprdVO cond) throws HAMException {
        RepaVbjaMeu07SikKrSprdDAO dao = RepaVbjaMeu07SikKrSprdDAOFactory.createRepaVbjaMeu07SikKrSprdDAO();
        List<RepaVbjaMeu07SikKrSprdVO> voList = dao.selectVoByDate(cond);

        // データがない場合
        if (voList.size() == 0) {
            //throw new HAMException("上位組織コード(局)取得エラー", "HF-W0011");
            return null;
        }
        return voList.get(0);
    }

    /**
     * 信用コードチェック
     *
     * @param sinCd 信用コード
     * @return true：OK、false：NG
     */
    private boolean checkSinCd(String sinCd) {
        String subjectCode = sinCd.substring(0, 1);
        for (int i = 0; i < SINCD_NOT_SUBJECT.length; i++) {
            if (SINCD_NOT_SUBJECT[i].equals(subjectCode)) {
                return false;
            }
        }
        return true;
    }

    /**
     * 検索条件を使用し、公開範囲/ユニットNo.マスタ情報の取得処理を実行します
     *
     * @param sikKaisoVO 組織・階層情報VO
     * @param sGI_result 職位等級グループ取得結果
     * @param tksInfoVO 得意先情報VO
     * @return 得意先情報（得意先リスト表示用）VOリスト
     * @throws CNPException 検索に失敗した場合
     */
    public KhUnMstVO getKhUnMstInfo(KhUnMstCondition cond) throws HAMException {

        MprKengenCheckDAO dao = MprKengenCheckDAOFactory.createMPRKengenChkDAO();
        List<KhUnMstVO> list = dao.getKhUnMstInfo(cond);
        // データが0件の場合
        if (list.size() == 0) {
            return null;
        }

        return list.get(0);
    }
}
