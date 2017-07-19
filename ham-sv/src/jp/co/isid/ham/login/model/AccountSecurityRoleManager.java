package jp.co.isid.ham.login.model;

import java.io.StringReader;
import java.util.Map;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import jp.co.isid.ham.model.base.HAMException;
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
public class AccountSecurityRoleManager {

    /** カテゴリー：相対権限 */
    private static final String CATEGORY_RELATIVE_AUTHORITY = "201";

    /** シングルトンインスタンス */
    private static AccountSecurityRoleManager _manager = new AccountSecurityRoleManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private AccountSecurityRoleManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static AccountSecurityRoleManager getInstance() {
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

            //return "31";
        } catch (Exception e) {
            //throw new HAMException("セキュリティデータ取得エラー", "HF-W0001");
            //新聞局ユーザーの対応のため、nullを返すように変更
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
        } else {
            throw new HAMException("セキュリティデータ取得エラー", "HF-W0001");
        }
    }

//    /**
//     * 管理者ユーザー情報の取得
//     *
//     * @param cond 検索条件
//     * @return 管理者ユーザー情報
//     * @throws HAMException 処理中にエラーが発生した場合
//     */
//    public Mhf31TntVO findKanriUserInfo(AccountSecurityRoleCondition cond) throws HAMException {
//
//    	KanriUserInfoDAO dao = KanriUserInfoDAOFactory.createKanriUserInfoDAO();
//
//    	List<Mhf31TntVO> list = dao.getKanriUserInfo(cond);
//
//    	// データが0件の場合
//        if (list.size() == 0) {
//            return null;
//        }
//
//    	return list.get(0);
//
//    }
}
