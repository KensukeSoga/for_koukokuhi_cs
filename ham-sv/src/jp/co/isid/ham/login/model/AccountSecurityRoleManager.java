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
 * �Ɩ���v�Z�L�����e�B���[���擾Manager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/05/17 JSE K.Tamura)<BR>
 * </P>
 *
 * @author JSE K.Tamura
 */
public class AccountSecurityRoleManager {

    /** �J�e�S���[�F���Ό��� */
    private static final String CATEGORY_RELATIVE_AUTHORITY = "201";

    /** �V���O���g���C���X�^���X */
    private static AccountSecurityRoleManager _manager = new AccountSecurityRoleManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private AccountSecurityRoleManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static AccountSecurityRoleManager getInstance() {
        return _manager;
    }

    /**
     * �Ɩ���v�Z�L�����e�B���[���i���Ό����j�̎擾
     *
     * @param cond ��������
     * @return �Ɩ���v�Z�L�����e�B���[���i���Ό����j
     * @throws HAMException �������ɃG���[�����������ꍇ
     */
    public String getAccountSecurityRole(AccountSecurityRoleCondition cond) throws HAMException {

        // ���O�C�����̒[�������擾
        SecurityInfo securityInfo = SecurityInfoUtil.deserialize(cond.getSecurityInfo());
        BaseUserInfo userInfo = (BaseUserInfo) securityInfo.getUserInfo();
        Map loginItemMap = userInfo.getLoginItems();

        // �Ɩ���v�̃f�B���N�g�����擾
        LoginParameter loginParameter = new LoginParameter();
        loginParameter.setAppId(cond.getAplId());
        loginParameter.setBrowser((String) loginItemMap.get("Browser"));
        loginParameter.setId(cond.getEsqId());
        loginParameter.setIpAddress((String) loginItemMap.get("IPAddr"));
        loginParameter.setOs((String) loginItemMap.get("OS"));
        loginParameter.setPass(cond.getPassword());
        loginParameter.setTerminalKind((String) loginItemMap.get("TerminalKind"));

        // �Ɩ���v�̃f�B���N�g�����擾
        NJSecurityStatelessService service = new NJSecurityStatelessService();
        LoginResult loginResult = service.login(loginParameter);

        // �Ɩ���v�̃��[�����擾
        GetSecurityRoleListParameter securityRoleListParameter = new GetSecurityRoleListParameter();
        securityRoleListParameter.setCategory(CATEGORY_RELATIVE_AUTHORITY);
        securityRoleListParameter.setSecurityInfo(loginResult.getSecurityInfo());
        GetSecurityRoleListResult securityRoleListResult = service.getSecurityRoleList(securityRoleListParameter);


        // �Ɩ���v�Z�L�����e�B���[���i���Ό����j��ԋp
        return getRelativeAuthority(securityRoleListResult.getResultXml());

    }

    /**
     * ���Ό����̎擾
     *
     * @param xmlRecords XML���
     * @return ���Ό���
     * @throws HAMException �������ɃG���[�����������ꍇ
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
            //throw new HAMException("�Z�L�����e�B�f�[�^�擾�G���[", "HF-W0001");
            //�V���ǃ��[�U�[�̑Ή��̂��߁Anull��Ԃ��悤�ɕύX
            return null;
        }

    }

    /**
     * �Ώۗv�f�擾
     *
     * @param xmlRecords XML���
     * @return ���Ό���
     * @throws HAMException �������ɃG���[�����������ꍇ
     */
    private static String getCharacterDataFromElement(Element e) throws HAMException {

        Node child = e.getFirstChild();
        if (child instanceof CharacterData) {
            CharacterData cd = (CharacterData) child;
            return StringUtil.trim(cd.getData());
        } else {
            throw new HAMException("�Z�L�����e�B�f�[�^�擾�G���[", "HF-W0001");
        }
    }

//    /**
//     * �Ǘ��҃��[�U�[���̎擾
//     *
//     * @param cond ��������
//     * @return �Ǘ��҃��[�U�[���
//     * @throws HAMException �������ɃG���[�����������ꍇ
//     */
//    public Mhf31TntVO findKanriUserInfo(AccountSecurityRoleCondition cond) throws HAMException {
//
//    	KanriUserInfoDAO dao = KanriUserInfoDAOFactory.createKanriUserInfoDAO();
//
//    	List<Mhf31TntVO> list = dao.getKanriUserInfo(cond);
//
//    	// �f�[�^��0���̏ꍇ
//        if (list.size() == 0) {
//            return null;
//        }
//
//    	return list.get(0);
//
//    }
}
