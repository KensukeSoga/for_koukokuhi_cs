package jp.co.isid.ham.menu.service;

import javax.jws.WebParam;
import javax.jws.WebService;

import jp.co.isid.ham.menu.controller.FindMainMenuCmd;
import jp.co.isid.ham.menu.model.FindMainMenuCondition;
import jp.co.isid.ham.menu.model.FindMainMenuResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.service.CommandInvokerUtil;
import jp.co.isid.soa.framework.service.exception.ExceptionHandler;
import jp.co.isid.soa.framework.service.exception.ServiceException;

/**
 *
 * <P>
 * ���j���[�T�[�r�X
 * </P>
 * <P>
 * ���j���[�T�[�r�X�N���X�ł�
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/10/04 JSE H.Abe)<BR>
 * </P>
 *
 * @author JSE H.Abe
 */
@WebService(serviceName = "menuService", targetNamespace = "http://service.menu.ham.isid.co.jp/")
public class MenuService {

    /**
     * ���C�����j���[�̕\���f�[�^���擾����
     *
     * @param condition ����
     * @return ��������
     * @throws ServiceException
     */
    public FindMainMenuResult findMainMenu(
            @WebParam(name = "condition") FindMainMenuCondition condition)
            throws ServiceException{

        try {
            FindMainMenuCmd cmd = new FindMainMenuCmd();
            cmd.setMainMenuCondition(condition);
            CommandInvokerUtil.getCommandInvoker().execute(cmd);
            return cmd.getMainMenuResult();
        } catch (HAMException e) {
            FindMainMenuResult result = new FindMainMenuResult();
            result.toErrorInfo(e);
            return result;
        } catch (Throwable e) {
            ExceptionHandler.getInstance().handleException(e);
            return null;
        }
    }
}